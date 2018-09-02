using UnityEngine;

namespace Scripts
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _smoothTime = 0.2f;

        private Vector3 _velocity;

        private void Update()
        {
            Vector3 targetPosition = _player.transform.position;
            targetPosition.z = transform.position.z;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
        }
    }
}
