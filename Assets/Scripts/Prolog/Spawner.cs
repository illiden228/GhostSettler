using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _timePast = 0;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        _timePast += Time.deltaTime;

        if(_timePast >= _secondsBetweenSpawn)
        {
            _timePast = 0;

            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
            Instantiate(_enemyPrefab, _spawnPoints[spawnPointNumber]);
        }
    }
}
