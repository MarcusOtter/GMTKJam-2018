using System;
using UnityEngine;

namespace Scripts
{
    public class PlayerInput : MonoBehaviour
    {
        internal static PlayerInput Instance;
        internal static event EventHandler AttackButtonDown = delegate { };
        internal static event EventHandler<Vector2> OnScrollWheelChange = delegate { };

        internal Vector3 MouseWorldPosition;

        [SerializeField] private KeyCode _attackButton;

        private Camera _mainCam;

        private void Awake()
        {
            SingletonCheck();
            _mainCam = Camera.main;
        }

        private void Update()
        {
            if (_mainCam == null) _mainCam = Camera.main;
            if (Input.GetKeyDown(_attackButton)) AttackButtonDown?.Invoke(this, EventArgs.Empty);

            if (Input.mouseScrollDelta != Vector2.zero) OnScrollWheelChange?.Invoke(this, Input.mouseScrollDelta);

            MouseWorldPosition = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        }

        private void SingletonCheck()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
