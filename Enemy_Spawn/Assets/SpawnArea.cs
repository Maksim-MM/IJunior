using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class SpawnArea : MonoBehaviour
{
    [SerializeField] private float _speedScailerMin = 0.5f;
    [SerializeField] private float _speedScailerMax = 1.3f;
        
    private float _speedRotation = 100f;
    private float _currentAngle;
    
    private Vector3 _finishAngle;
    private Vector3 _startAngle;
    
    private bool _isPositiveRotation = true;

    private void Awake()
    {
        _speedRotation *= Random.Range(_speedScailerMin, _speedScailerMax);
    }

    private void Start()
    {
         _startAngle = new Vector3(0f, transform.localRotation.y + 90f, 0f);
         _finishAngle = new Vector3(0f, transform.localRotation.y - 90f, 0f);
    }

    private void Update()
    {
       MakeRotate();
    }

    private void MakeRotate()
    {
        Vector3 targetAngle = _isPositiveRotation ? _startAngle : _finishAngle;
        
        Quaternion targetRotation = Quaternion.Euler(targetAngle);

        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, 
            _speedRotation * Time.deltaTime);

        if (transform.localRotation == targetRotation)
        {
            _isPositiveRotation = !_isPositiveRotation;
        }
    }
}
