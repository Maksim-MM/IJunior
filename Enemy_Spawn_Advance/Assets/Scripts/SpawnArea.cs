using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnArea : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Enemy _enemy;
    
    private Vector3 _spawnOffset = new Vector3(0f, 0.75f, 0f);
    
    private float _randomAngle;
    private float _randomRadius;
    private float _radiusScaler = 2f;

    private void Update()
    {
        transform.LookAt(_target);
    }
    
    public void SpawnEnemy()
    {
        Vector3 spawnPoint = GetSpawnPoint();
        Enemy newEnemy = Instantiate(_enemy, spawnPoint , Quaternion.identity);
        newEnemy.SetTarget(_target);
    }
    
    private Vector3 GetSpawnPoint()
    {
        _randomAngle = Random.Range(0f, 360f);
        _randomRadius = Random.Range(0f, GetSpawnerRadius());
        
        Vector3 centerPosition = transform.position;
        Vector3 randomVector = Quaternion.Euler(0f, _randomAngle, 0f) * Vector3.right * _randomRadius;
        Vector3 randomPoint = centerPosition + _spawnOffset + randomVector;

        return randomPoint;
    }
    
    private float GetSpawnerRadius()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        return mesh.bounds.size.x/_radiusScaler;
    }
}
