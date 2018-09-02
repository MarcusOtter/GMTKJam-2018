using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Weapons
{
    public class Shotgun : Weapon
    {
        [Header("Shotgun settings")]
        [SerializeField] private List<Transform> _bulletSpawners;

        public override void Shoot()
        {
            foreach (var bulletSpawner in _bulletSpawners)
            {
                Instantiate(BulletToShoot, bulletSpawner.position, bulletSpawner.rotation);
                transform.root.GetComponentInChildren<PlayerController>().Knockback(PlayerKnockback);
            }

            base.Shoot();
        }
    }
}
