using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpriteEventTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent _onMouseDown;
    bool _interactable = true;

    public void SetInteractable(bool interactable)
    {
        _interactable = interactable;
    }
    void OnMouseDown()
    {
        if(!_interactable) return;
        _onMouseDown?.Invoke();
    }
}
