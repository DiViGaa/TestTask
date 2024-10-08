using System;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private AudioClip _hoverSound;
    [SerializeField] private AudioClip _clickSound;
    
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayHoverSound()
    {
        _audioSource.PlayOneShot(_hoverSound);
    }

    public void PlayPressSound()
    {
        _audioSource.PlayOneShot(_clickSound);
    }
}
