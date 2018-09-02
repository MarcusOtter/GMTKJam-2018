using UnityEngine;

namespace Scripts
{
    public class RotatePlayer : MonoBehaviour
    {
        private void FixedUpdate ()
        {
            Vector2 lookDirection = (PlayerInput.Instance.MouseWorldPosition - transform.position).normalized;
            transform.up = lookDirection;
        }
    }
}
