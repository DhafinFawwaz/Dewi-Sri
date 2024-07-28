using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwipeHint : MonoBehaviour
{
    [SerializeField] float _angle = 45;
    [SerializeField] float _angleTolerance = 10;
    [SerializeField] float _maxDuration = 1;
    [SerializeField] float _minDistance = 1;
    [SerializeField] UnityEvent _onSwipe;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(0, 0, _angle) * Vector3.right * _minDistance);
    }

    bool _isSwiping = false;
    Vector3 _startMousePos;
    float _startTime;
    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     _startMousePos = Input.mousePosition;
        //     _startTime = Time.time;
        //     _isSwiping = true;
        // }

        // if (Input.GetMouseButtonUp(0) && _isSwiping)
        // {
        //     _isSwiping = false;
        //     Vector3 endMousePos = Input.mousePosition;
        //     Vector3 diff = endMousePos - _startMousePos;
        //     diff.Normalize();
        //     float angle = Vector3.Angle(Vector3.right, diff);
        //     if (angle < _angle + _angleTolerance && angle > _angle - _angleTolerance && diff.magnitude > _minDistance && Time.time - _startTime < _maxDuration)
        //     {
        //         _onSwipe?.Invoke();
        //     }
        // }


        
        if (Input.GetMouseButtonDown(0))
        {
            _startMousePos = Input.mousePosition;
            _startTime = Time.time;
            _isSwiping = true;
        }
        if(Input.GetMouseButtonUp(0) && _isSwiping) {
            _isSwiping = false;
        }

        if(_isSwiping) {
            Vector3 endMousePos = Input.mousePosition;
            float distance = Vector3.Distance(_startMousePos, endMousePos);
            if(distance > _minDistance) {
                _onSwipe?.Invoke();
                _isSwiping = false;
            }
        }
    }
}
