using UnityEngine;
using UnityEngine.Serialization;

public class SelectBullet : MonoBehaviour
{ 
   [SerializeField] private Pistol _pistol;
   [SerializeField] private GameObject bulletPrefab;

   public void GetBulletPrefab() => _pistol.BulletPrefab = bulletPrefab;

}
