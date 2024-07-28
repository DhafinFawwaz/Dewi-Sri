using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFollowMouse : MonoBehaviour
{
    [SerializeField] SpriteMask _mask;
    Camera _mainCam;
    void Awake()
    {
        _mainCam = Camera.main;
    }

    void Update()
    {
        // Get touch position
        if(Input.touchCount > 0)
        {
            Vector3 touchPos = _mainCam.ScreenToWorldPoint(Input.GetTouch(0).position);
            touchPos.z = 0;
            transform.position = touchPos;
            return;
        } else {
            Vector3 mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }

        if(Input.GetMouseButtonDown(0))
        {
            _mask.enabled = true;
        } else if(Input.GetMouseButtonUp(0))
        {
            _mask.enabled = false;
        }
    }
}
