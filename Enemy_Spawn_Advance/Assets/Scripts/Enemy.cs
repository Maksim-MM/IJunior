using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _movingSpeed = 10f;
    
    private Transform _target;
    
    private Vector3 _targetOffset = new Vector3(0, 0.5f, 0);
    
    private float _destroyDelay = 5f;

    private void Update()
    {
        if (_target != null)
        {
            Vector3 targetPosition = _target.position + _targetOffset;
            
            Vector3 directionToTarget = (targetPosition - transform.position).normalized;
            
            transform.Translate(directionToTarget * _movingSpeed * Time.deltaTime, Space.World);
        }

        DestroyObjectDelayed();
    }
    
    private void DestroyObjectDelayed() => Destroy(gameObject, _destroyDelay);
    
    public void SetTarget(Transform target) => _target = target;
}
