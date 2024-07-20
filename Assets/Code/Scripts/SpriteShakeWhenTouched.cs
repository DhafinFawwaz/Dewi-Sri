using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpriteShakeWhenTouched : MonoBehaviour
{
    Vector3 _start;
    Vector3 _end;
    [SerializeField] float _sideLength = 0.2f;
    [SerializeField] float _duration = 0.3f;
    [SerializeField] float _frequency = 5f;
    [SerializeField] UnityEvent _onShake; 

    void Awake()
    {
        _start = transform.position;
        _end = _start + Vector3.right * _sideLength;
    }
    void OnMouseDown()
    {   
        StartCoroutine(TweenPosition());
        _onShake?.Invoke();
    }


    byte _posKey;
    IEnumerator TweenPosition()
    {
        byte requirement = ++_posKey;
        float t = 0;
        while(t < 1 && requirement == _posKey)
        {
            t += Time.deltaTime / _duration;
            transform.position = Vector3.LerpUnclamped(_start, _end, sineParabolic(t));
            yield return null;
        }
        if(requirement == _posKey)
        {
            transform.position = _start;
        }
    }



    float sineParabolic(float x)
    {
        return (-4*(x-0.5f)*(x-0.5f)+1) * Mathf.Sin(Mathf.PI*x*_frequency);
    }

}
