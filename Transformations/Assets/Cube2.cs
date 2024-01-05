using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube2 : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _cube2Speed;
    [SerializeField] private float _rotationSpeed;

    private int _currentWaypoint = 0;
    
    void Update()
    {
        MoveСircleCube();
    }
    
    private void MoveСircleCube()
    {
        if (transform.position == _waypoints[_currentWaypoint].position)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(
            transform.position, _waypoints[_currentWaypoint].position, _cube2Speed * Time.deltaTime);
        
        Vector3 directionToTarget = _waypoints[_currentWaypoint].position - transform.position;
        
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}
