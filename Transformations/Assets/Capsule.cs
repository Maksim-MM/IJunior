using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    [SerializeField] private float _сapsuleSpeedResize;
    
    private Vector3 _сapsuleStartSize;
    private Vector3 _сapsuleNewSize = new Vector3(1f,1f,1f);
    
    private bool _isGrowing = true;
    
    void Start()
    {
        _сapsuleStartSize = transform.localScale;
    }

    void Update()
    {
        ResizeCapsule();
    }
    
    private void ResizeCapsule()
    {
        Vector3 сapsuleCurrentScale = transform.localScale;
        
        if (_isGrowing)
        {
            transform.localScale = MoveTowards(сapsuleCurrentScale, _сapsuleNewSize, _сapsuleSpeedResize);

            if (IsEqual(сapsuleCurrentScale, _сapsuleNewSize)) SwitchValue(ref _isGrowing);
        }
        else
        {
            transform.localScale = MoveTowards(сapsuleCurrentScale, _сapsuleStartSize, _сapsuleSpeedResize);
            
            if (IsEqual (сapsuleCurrentScale, _сapsuleStartSize)) SwitchValue(ref _isGrowing);
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
