using System.Collections;
using UnityEngine;

public abstract class AbstractGun : MonoBehaviour
{
    public float _delayBeforeFiring = 1f;
    public float _shotForce = 50f;
    
    public abstract IEnumerator Shoot();
}
