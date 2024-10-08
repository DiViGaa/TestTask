using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RicochetBullet : AbstractBullet
{
    [SerializeField] private float _bulletSpeed = 20f;
    [SerializeField] private int _maxBulletRicochets = 3;
    [SerializeField] private float _ricochetRadius = 5f;
    [SerializeField] private LayerMask damageLayer;
    
    private List<Transform> _hitEnemies = new List<Transform>();
    private int _currentRicochets;
    
    public override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<AbstractParameters>().TakeHit();
            Ricochet(other.transform);
        }
    }

    private void Ricochet(Transform enemy)
{
    _currentRicochets++;
    _hitEnemies.Add(enemy);

    if (_currentRicochets >= _maxBulletRicochets)
    {
        transform.DOKill();
        Destroy(gameObject);
        return;
    }

    var nextTarget = FindNearestEnemy(enemy.position);

    if (nextTarget != null)
        MoveToTarget(nextTarget);
    
    else
        Destroy(gameObject);
}

private Transform FindNearestEnemy(Vector3 hitPosition)
{
    Collider[] hits = Physics.OverlapSphere(hitPosition, _ricochetRadius, damageLayer);

    Transform nearestEnemy = null;
    float nearestDistance = Mathf.Infinity;

    foreach (Collider hit in hits)
    {
        if (hit.CompareTag("Enemy") && !_hitEnemies.Contains(hit.transform))
        {
            float distance = (hitPosition - hit.transform.position).sqrMagnitude;

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = hit.transform;
            }
        }
    }

    return nearestEnemy;
}

private void MoveToTarget(Transform target)
{
    Vector3 targetCenter = GetTargetCenter(target);
    transform.DOMove(targetCenter, _bulletSpeed / 20f);
}

private Vector3 GetTargetCenter(Transform target)
{
    Collider targetCollider = target.GetComponent<Collider>();
    return targetCollider.bounds.center;
}

    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _ricochetRadius);
    }

}
