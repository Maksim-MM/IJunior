using System.Collections;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnArea[] _spawnAreas;
    
    private float _spawnDelay = 2f;
    
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

            foreach (var area in _spawnAreas) area.SpawnEnemy();
        }
    }
}
