using System.Collections;
using System.Collections.Generic;
using DhafinFawwaz.Tweener;
using UnityEngine;

public class Page10Manager : MonoBehaviour
{
    int _trashCounter = 0;
    [SerializeField] int _trashLimit = 10;
    [SerializeField] TransformTweener _showPopUp;
    [SerializeField] ImageTweener _showPopUpBlack;
    [SerializeField] ImageTweener _showPopUpBlur;
    [SerializeField] SpriteRendererTweener _kolamTweener;
    [SerializeField] SpriteRenderer _kodok;
    [SerializeField] Sprite[] _kodokSprites;
    [SerializeField] GameObject _canvas;
    public void IncrementTrashCounter()
    {
        if(_trashCounter >= _trashLimit) return;
        _trashCounter++;
        if(_trashCounter >= _trashLimit) {
            _canvas.SetActive(true);
            _showPopUp.LocalScale();
            _showPopUpBlack.Color();
            _showPopUpBlur.Color();
        }
        _kolamTweener.SetEnd(new Color(1, 1, 1, _trashCounter/(float)_trashLimit)).Color();

        if(_trashCounter == 3) _kodok.sprite = _kodokSprites[1];
        else if(_trashCounter == 6) _kodok.sprite = _kodokSprites[2];
        else if(_trashCounter == _trashLimit-1) _kodok.sprite = _kodokSprites[3];
    }
}
