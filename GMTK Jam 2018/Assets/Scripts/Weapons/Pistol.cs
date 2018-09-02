using UnityEngine;

namespace Scripts.Weapons
{
    public class Pistol : Weapon
    {
        [Header("Pistol settings")]
        [SerializeField] private Transform _bulletSpawner;

        public override void Shoot()
        {
            Instantiate(BulletToShoot, _bulletSpawner.position, _bulletSpawner.rotation);
            transform.root.GetComponentInChildren<PlayerController>().Knockback(PlayerKnockback);
            base.Shoot();
        }
    }
}
