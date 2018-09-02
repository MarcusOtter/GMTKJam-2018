using System.Collections;
using System.Collections.Generic;
using Scripts.Weapons;
using UnityEngine;
using TMPro;

public class AmmoObserver : MonoBehaviour
{
    [SerializeField] private Weapon _weaponToObserve;
    [SerializeField] private TMP_Text _temp;

    private void Update()
    {
        _temp.text = _weaponToObserve.AmmoRemaining.ToString();
    }
}
