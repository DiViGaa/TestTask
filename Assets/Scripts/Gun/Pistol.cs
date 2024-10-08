using System;
using System.Collections;
using UnityEngine;
public class Pistol : AbstractGun
{
    [SerializeField] private Transform bulletSpawn;
    
    private GameObject _bulletPrefab;
    private PistolSound _pistolSound;
    public GameObject BulletPrefab
    {
        get
        {
            return _bulletPrefab;
        }
        set
        {
            _bulletPrefab = value;
        }
    }

    private void Start()
    {
        _pistolSound = GetComponent<PistolSound>();
    }

    private void Update()
    {
        if (_bulletPrefab != null)
            StartCoroutine(Shoot());
    }

    public override IEnumerator Shoot()
    {
        if (KeyboardInput.SpaceIsPressed())
        {
            yield return new WaitForSeconds(_delayBeforeFiring);
            _pistolSound.PlayShootSound();
            var bullet = Instantiate(_bulletPrefab, bulletSpawn.position, Quaternion.Euler(90,0,0));
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * _shotForce, ForceMode.Impulse);
        }
    }
}
