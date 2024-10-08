using UnityEngine;

public class DefaultBullet : AbstractBullet
{
    public override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<AbstractParameters>().TakeHit();
            Destroy(gameObject);
        }
    }
}
