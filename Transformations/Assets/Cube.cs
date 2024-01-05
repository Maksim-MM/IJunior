using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _cubeSpeedRotation;

    void Update()
    {
        RotateCube();
    }
    
    private void RotateCube()
    {
        transform.RotateAround(transform.position, Vector3.up, _cubeSpeedRotation * Time.deltaTime);
    }
}
