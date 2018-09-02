using System;
using UnityEngine;

namespace Scripts.Weapons
{
    // Base class for weapons
    public class Weapon : MonoBehaviour
    {
        public int DamagePerBullet;
        public int BulletsPerShot;
        public int BulletSpeed;
        public float PlayerKnockback;

        [SerializeField] protected WeaponHolder Holder;

        private void OnEnable()
        {
            PlayerInput.AttackButtonDown += Shoot;
        }

        public virtual void Shoot(object sender, EventArgs args)
        {
            //overwritten
        }

        private void OnDisable()
        {
            PlayerInput.AttackButtonDown -= Shoot;
        }
    }
}
