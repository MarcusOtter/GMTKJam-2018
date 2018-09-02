using System.Collections.Generic;
using Scripts;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private GameObject _ammoPickupPrefab;
    [SerializeField] private float _ammoPickupSpawnDelay = 20;
    [SerializeField] private List<Transform> _ammoSpawnPoints;

    private float _lastAmmoPickupSpawnTime;

    private void Start()
    {
        InvokeRepeating(nameof(DecreaseAmmoPickupSpawnRate), 10, 10);
    }

    private void Update()
    {
        transform.Rotate(0, 0, _rotationSpeed);

        if (Time.time < _lastAmmoPickupSpawnTime + _ammoPickupSpawnDelay) return;

        var ammoSpawnPoint = _ammoSpawnPoints[Random.Range(0, _ammoSpawnPoints.Count)];
        Instantiate(_ammoPickupPrefab, ammoSpawnPoint);
        _lastAmmoPickupSpawnTime = Time.time;
    }

    private void DecreaseAmmoPickupSpawnRate()
    {
        _ammoPickupSpawnDelay *= 0.96f;
        Debug.Log("decreased");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerController>();
        var enemy = other.GetComponent<Enemy>();

        if (!player && !enemy) return;

        other.transform.parent = transform;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerController>();
        var enemy = other.GetComponent<Enemy>();

        if (!player && !enemy) return;
        other.transform.parent = null;
    }
}
