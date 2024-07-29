using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseFollow : MonoBehaviour
{

    [SerializeField] ParticleSystem _particleSystem;   
    [SerializeField] float _rate = 10;
    [SerializeField] UnityEvent _onMouseDown;
    [SerializeField] UnityEvent _onMouseUp;
    bool _isMouseDown = false;
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0) && !_isMouseDown)
        {
            var emission = _particleSystem.emission;
            emission.rateOverTime = _rate;
            _isMouseDown = true;
            _onMouseDown?.Invoke();
        }
        else if(Input.GetMouseButtonUp(0) && _isMouseDown)
        {
            var emission = _particleSystem.emission;
            emission.rateOverTime = 0;
            _isMouseDown = false;
            _onMouseUp?.Invoke();
        }
    }
}
