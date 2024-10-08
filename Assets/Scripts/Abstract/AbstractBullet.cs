using System;
using UnityEngine;

public abstract class AbstractBullet : MonoBehaviour
{
    public abstract void OnCollisionEnter(Collision other);
}
