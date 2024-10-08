using UnityEngine;


public class ExplosiveBullet : AbstractBullet
{
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private LayerMask _damageLayer;
    [SerializeField] private GameObject _explosionEffectc;
    
    public override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(_explosionEffectc,transform.position,Quaternion.identity);
            Explode();
        }
    }
    
    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius, _damageLayer);
        foreach (Collider nearbyObject in colliders)
        {
            nearbyObject.gameObject.GetComponent<AbstractParameters>().TakeHit();
        }

        Destroy(gameObject);    
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }

}
