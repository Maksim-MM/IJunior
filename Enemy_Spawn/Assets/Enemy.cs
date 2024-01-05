using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _movingSpeed = 10f;
    
    private Vector3 _currentPosition;

    private Vector3 _direction;
    
    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        Vector3 currentPosition = transform.position;

        Vector3 newPosition = currentPosition + _direction * _movingSpeed * Time.deltaTime;
        
        transform.position = newPosition;
    }
}
