using System;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    private ParticleSystem _explosionParticalSystem;
    void Start()
    {
        _explosionParticalSystem = GetComponent<ParticleSystem>();
        _explosionParticalSystem.Play();
    }

    private void Update()
    {
        if (_explosionParticalSystem.isStopped)
        {
            Destroy(gameObject);
        }
    }
}
