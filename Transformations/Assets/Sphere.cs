using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private float _sphereSpeed;
    [SerializeField] private Transform _sphereEndpoint;
    
    private Vector3 _sphereStartPosition;
    private Vector3 _sphereFinishPosition;
    
    private bool _isMovingForward = true;
    
    void Start()
    {
        _sphereStartPosition = transform.position;
        
        _sphereFinishPosition = _sphereEndpoint.position;
    }
    
    void Update()
    {
        MoveSphere();
    }
    
    private void MoveSphere()
    {
        if (_isMovingForward)
        {
            transform.position = MoveTowards(transform.position, _sphereFinishPosition, _sphereSpeed);
        
            if (IsEqual (transform.position,_sphereFinishPosition)) SwitchValue(ref _isMovingForward);
        }
        else
        {
            transform.position = MoveTowards(transform.position, _sphereStartPosition, _sphereSpeed);
        
            if (IsEqual (transform.position,_sphereStartPosition)) SwitchValue(ref _isMovingForward);
        }
    }
    
    private Vector3 MoveTowards(Vector3 start, Vector3 finish, float speed)
    {
        Vector3 position = Vector3.MoveTowards(start, finish, speed * Time.deltaTime);

        return position;
    }
    
    private void SwitchValue(ref bool value)
    {
        value = !value;
    }
    
    private bool IsEqual(Vector3 firstVector, Vector3 secondVector) => (firstVector == secondVector);
}
