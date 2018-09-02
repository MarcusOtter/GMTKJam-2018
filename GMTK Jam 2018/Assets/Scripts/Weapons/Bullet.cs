using UnityEngine;

namespace Scripts.Weapons
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _bulletSpeed;

        private Rigidbody2D _rigidbody;

        private Collider2D _colliderToIgnore;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.AddForce(transform.up * _bulletSpeed, ForceMode2D.Impulse);
            Destroy(transform.root.gameObject, 5);

            _colliderToIgnore = FindObjectOfType<RotatePlatform>().GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), _colliderToIgnore);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            other.GetComponent<Enemy>()?.Damage(_damage);
            
            Destroy(transform.root.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            other.collider.GetComponent<Enemy>()?.Damage(_damage);

            Destroy(transform.root.gameObject);
        }
    }
}
