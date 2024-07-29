using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFollowMouse : MonoBehaviour
{
    [SerializeField] SpriteMask _mask;   
    bool _isMouseDown = false;
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        if(Input.GetMouseButtonDown(0) && !_isMouseDown)
        {
            _mask.enabled = true;
            _isMouseDown = true;
        }
        else if(Input.GetMouseButtonUp(0) && _isMouseDown)
        {
            _mask.enabled = false;
            _isMouseDown = false;
        }
    }
}
