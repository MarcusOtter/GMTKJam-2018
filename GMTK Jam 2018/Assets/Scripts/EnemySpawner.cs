using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _startingSpawnDelay = 4;
    [SerializeField] private float _delayDecreasePerSpawnPercent = 4;

    private float _spawnDelay;
    private float _lastSpawnTime;

    private void Start()
    {
        _spawnDelay = _startingSpawnDelay;
        InvokeRepeating(nameof(DecreaseSpawnDelay), 5, 5);
    }

    private void Update()
    {
        SpawnBehaviour();
    }

    private void DecreaseSpawnDelay()
    {
        _spawnDelay *= (1 - (_delayDecreasePerSpawnPercent / 100f));
        Debug.Log($"New spawn delay: {_spawnDelay}");
    }

    private void SpawnBehaviour()
    {
        if (Time.time < _lastSpawnTime + _spawnDelay) return;

        var spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
        Instantiate(_enemyPrefab, spawnPoint.position, Quaternion.identity);

        _lastSpawnTime = Time.time;
    }
}
