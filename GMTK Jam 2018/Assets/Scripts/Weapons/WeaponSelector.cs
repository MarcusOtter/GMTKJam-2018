using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Weapons
{
    public class WeaponSelector : MonoBehaviour
    {
        [SerializeField] internal List<WeaponUiElement> AvailableWeapons;

        internal Weapon ActiveWeapon { get; private set; }

        private int _activeWeaponIndex; // 0 based

        private void OnEnable()
        {
            PlayerInput.OnScrollWheelChange += ChangeActiveWeaponHandler;
        }

        private void Start()
        {
            ChangeWeaponTo(0);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) ChangeWeaponTo(0);
            else if (Input.GetKeyDown(KeyCode.Alpha2)) ChangeWeaponTo(1);
            else if (Input.GetKeyDown(KeyCode.Alpha3)) ChangeWeaponTo(2);
        }

        private void ChangeActiveWeaponHandler(object sender, Vector2 scrollDirection)
        {
            ChangeWeapon(scrollDirection);
        }

        private void ChangeWeaponTo(int index)
        {
            ActiveWeapon?.gameObject.SetActive(false);
            AvailableWeapons[_activeWeaponIndex].UiImage.enabled = false;

            _activeWeaponIndex = index;

            if (_activeWeaponIndex > AvailableWeapons.Count - 1)
            {
                _activeWeaponIndex = 0;
            }
            else if (_activeWeaponIndex < 0)
            {
                _activeWeaponIndex = AvailableWeapons.Count - 1;
            }

            ActiveWeapon = AvailableWeapons[_activeWeaponIndex].Weapon;
            ActiveWeapon.gameObject.SetActive(true);
            AvailableWeapons[_activeWeaponIndex].UiImage.enabled = true;
        }

        private void ChangeWeapon(Vector2 scrollDirection)
        {
            if (scrollDirection == Vector2.up)
            {
                ChangeWeaponTo(_activeWeaponIndex + 1);
            }
            else if (scrollDirection == Vector2.down)
            {
                ChangeWeaponTo(_activeWeaponIndex - 1);
            }
        }

        private void OnDisable()
        {
            PlayerInput.OnScrollWheelChange -= ChangeActiveWeaponHandler;
        }
    }

    [Serializable]
    public class WeaponUiElement
    {
        public Weapon Weapon;
        public Image UiImage;
    }
}
