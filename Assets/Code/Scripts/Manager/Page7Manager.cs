using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Page7Manager : MonoBehaviour
{
    [SerializeField] SpriteRenderer _anak;
    [SerializeField] Sprite _anakSenang;
    [SerializeField] ButuhGaButuh _butuhGaButuh;
    [SerializeField] UnityEvent _onFinish;

    [SerializeField]
    int _state = 0;
    public void NextState()
    {
        _state++;
        DoneCheck();
    }
    public void DoneCheck()
    {
        if(_state == 5)
        {
            _anak.sprite = _anakSenang;
            _butuhGaButuh.StopAnyRunningCoroutine();
            _onFinish?.Invoke();
        }
    }
}
