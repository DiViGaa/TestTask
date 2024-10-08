using UnityEngine;

public class PistolSound : MonoBehaviour
{
    [SerializeField] private AudioClip _shootSound;
    
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayShootSound()
    {
        _audioSource.PlayOneShot(_shootSound);
    }
}
