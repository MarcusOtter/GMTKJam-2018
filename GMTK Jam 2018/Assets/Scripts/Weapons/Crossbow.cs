using UnityEngine;

namespace Scripts.Weapons
{
    [RequireComponent(typeof(LineRenderer))]
    public class Crossbow : Weapon
    {
        [Header("Crossbow settings")]
        [SerializeField] private Transform _bulletSpawner;
        private LineRenderer _aimingGuide;

        protected override void Awake()
        {
            _aimingGuide = GetComponent<LineRenderer>();
            base.Awake();
        }

        private void Update()
        {
            _aimingGuide.positionCount = 2;
            _aimingGuide.SetPosition(0, transform.position);
            _aimingGuide.SetPosition(1, transform.up * 1000 + transform.position);
        }
        
        
        public override void Shoot()
        {
            Instantiate(BulletToShoot, _bulletSpawner.position, _bulletSpawner.rotation);
            transform.root.GetComponentInChildren<PlayerController>().Knockback(PlayerKnockback);
            base.Shoot();
        }
    }
}
