using Scripts;
using Scripts.Weapons;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private int _weapon;
    private int _ammoAmount;

    private void Awake()
    {
        _weapon = Random.Range(0, 3);

        switch (_weapon)
        {
            case 0:
                _ammoAmount = Random.Range(10, 21);
                break;
            case 1:
                _ammoAmount = Random.Range(20, 36);
                break;
            case 2:
                _ammoAmount = Random.Range(5, 11);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerController>();

        if (player == null) return;
        FindObjectOfType<WeaponSelector>().AvailableWeapons[_weapon].Weapon.AddAmmo(_ammoAmount);
        Destroy(gameObject);
    }
}
