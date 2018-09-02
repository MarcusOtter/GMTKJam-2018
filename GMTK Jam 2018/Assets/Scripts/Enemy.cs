using UnityEngine;

namespace Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _startingHitPoints = 2;

        private Transform _player;
        private Rigidbody2D _rigidbody;

        private float _hitPoints;
        private Vector3 _playerDirection;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _player = FindObjectOfType<PlayerController>().transform;
            _hitPoints = _startingHitPoints;
        }

        private void Update()
        {
            _playerDirection = (_player.position - transform.position).normalized;
            Move();
            Turn();
        }

        private void Turn()
        {
            transform.up = _playerDirection;
        }

        private void Move()
        {
            _rigidbody.velocity = _playerDirection * _movementSpeed;
        }

        internal void Damage(int incomingDamage)
        {
            _hitPoints -= incomingDamage;
            HpCheck();
        }
        
        private void HpCheck()
        {
            if (_hitPoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
