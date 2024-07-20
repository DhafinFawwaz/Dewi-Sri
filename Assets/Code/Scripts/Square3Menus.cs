using System.Collections;
using System.Collections.Generic;
using DhafinFawwaz.Tweener;
using UnityEngine;

public class Square3Menus : MonoBehaviour
{
    [SerializeField] RectTransformTweener[] _showTweeners;
    [SerializeField] RectTransformTweener[] _hideTweeners;
    [SerializeField] ImageTweener[] _imageTweeners;

    bool _isOpen = false;
    public void Toggle()
    {
        _isOpen = !_isOpen;
        if (_isOpen) {
            for(int i = 0; i < _showTweeners.Length; i++) {
                _showTweeners[i].gameObject.SetActive(true);
                _showTweeners[i].AnchoredPosition();
                _imageTweeners[i].SetEndColor(new Color(1,1,1,1)).Color();
            }
        }
        else {
            for(int i = 0; i < _imageTweeners.Length; i++) {
                _hideTweeners[i].AnchoredPosition();
                _imageTweeners[i].SetEndColor(new Color(1,1,1,0)).Color();
            }
        }
        
    }
}
