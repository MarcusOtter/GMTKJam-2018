using System;
using UnityEngine;

namespace Scripts.Weapons
{
    // Base class for weapons
    public class Weapon : MonoBehaviour
    {
        [Header("General Weapon Settings")]
        public string WeaponName;
        public GameObject BulletToShoot;
        public float PlayerKnockback;
        public int StartAmmo;
        public float ShootCooldown;
        public AudioClip ShootSound;

        public int AmmoRemaining { get; protected set; }
        private float _lastShootTime;
        private AudioSource _audioSource;

        protected virtual void Awake()
        {
            AmmoRemaining = StartAmmo;
            _audioSource = GetComponentInParent<AudioSource>();
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            PlayerInput.AttackButtonDown += ShootHandler;
        }

        private void ShootHandler(object sender, EventArgs args)
        {
            if (AmmoRemaining <= 0)
            {
                Debug.Log($"{WeaponName} is out of ammo.");
                return;
            }

            if (Time.time < _lastShootTime + ShootCooldown)
            {
                Debug.Log($"{WeaponName} is on cooldown");
                return;
            }

            Shoot();
            AmmoRemaining--;
            _lastShootTime = Time.time;
        }

        internal void AddAmmo(int amountOfShotsToAdd)
        {
            AmmoRemaining += amountOfShotsToAdd;
        }

        public virtual void Shoot()
        {
            _audioSource.PlayOneShot(ShootSound, 0.5f);
            //overwritten
        }

        private void OnDisable()
        {
            PlayerInput.AttackButtonDown -= ShootHandler;
        }
    }
}
