using UnityEngine;

public class Rogue : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private int _currentWaypoint = 0;

    private void Update()
    {
        MoveRogue();
    }

    private void MoveRogue()
    {
        if (transform.position == _waypoints[_currentWaypoint].position)
        {
            _currentWaypoint = (++_currentWaypoint) % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(
            transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
        
        Vector3 directionToTarget = _waypoints[_currentWaypoint].position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}
