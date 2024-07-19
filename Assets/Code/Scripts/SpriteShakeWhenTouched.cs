using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteShakeWhenTouched : MonoBehaviour
{
    Vector3 _start;
    Vector3 _end;
    [SerializeField] float _sideLength = 1f;
    [SerializeField] float _duration = 1f;
    [SerializeField] float _frequency = 10f;

    void Awake()
    {
        _start = transform.position;
        _end = _start + Vector3.right * _sideLength;
    }
    void OnMouseDown()
    {   
        StartCoroutine(TweenPosition());
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
