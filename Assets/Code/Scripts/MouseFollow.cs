using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{

    [SerializeField] ParticleSystem _particleSystem;   
    [SerializeField] float _rate = 10;
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0))
        {
            var emission = _particleSystem.emission;
            emission.rateOverTime = _rate;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            var emission = _particleSystem.emission;
            emission.rateOverTime = 0;
        }
    }
}
