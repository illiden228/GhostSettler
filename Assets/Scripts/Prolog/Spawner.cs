using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _timePast = 0;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<Transform>();
        Initialize(_enemyPrefab);
    }

    private void Update()
    {
        _timePast += Time.deltaTime;

        if(_timePast >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _timePast = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
