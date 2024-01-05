using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform[] _spawners;
    
    private Vector3 _spawnOffset = new Vector3(0f, 0.75f, 0f);

    private float _spawnDelay = 2f;
    private float _randomAngle;
    private float _randomRadius;
    
    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_spawnDelay);
        
        StartCoroutine(SpawnLoop());
    }
    
    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return _wait;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        foreach (var spawner in _spawners)
        {
            Vector3 spawnPoint = GetSpawnPoint(spawner);

            Enemy newEnemy = Instantiate(_enemy, spawnPoint , Quaternion.identity);
        
            newEnemy.SetDirection(spawner.transform.right);
        }
    }
    
    private Vector3 GetSpawnPoint(Transform spawner)
    {
        _randomAngle = Random.Range(0f, 360f);
        _randomRadius = Random.Range(0f, GetSpawnerRadius(spawner));
        
        Vector3 centerPosition = spawner.transform.position;

        Vector3 randomVector = Quaternion.Euler(0f, _randomAngle, 0f) * Vector3.right * _randomRadius;
        
        Vector3 randomPoint = centerPosition + _spawnOffset + randomVector;

        return randomPoint;
    }
    
    private float GetSpawnerRadius(Transform spawnArea)
    {
        Mesh mesh = spawnArea.GetComponent<MeshFilter>().mesh;
        
        float radius = mesh.bounds.size.x;

        return radius;
    }
}
