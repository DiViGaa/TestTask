using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    [SerializeField] private AudioClip _hitSound;
    
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayHitSound()
    {
        _audioSource.PlayOneShot(_hitSound);
    }
}
