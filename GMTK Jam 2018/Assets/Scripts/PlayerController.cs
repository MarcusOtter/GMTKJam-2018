using UnityEngine;

namespace Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Knockback(float force)
        {
            _rigidbody.AddForce(-transform.up * force, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var deathObject = other.GetComponent<DeathObject>();
            if (deathObject != null)
            {
                SceneController.Instance.TryLoadScene(2);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var deathObject = other.collider.GetComponent<DeathObject>();
            if (deathObject != null)
            {
                SceneController.Instance.TryLoadScene(2);
            }
        }
    }
}

