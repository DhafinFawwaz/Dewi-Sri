using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page7Manager : MonoBehaviour
{
    [SerializeField] SpriteRenderer _anak;
    [SerializeField] Sprite _anakSenang;
    [SerializeField] ButuhGaButuh _butuhGaButuh;

    int _state = 0;
    public void NextState()
    {
        _state++;
    }
    public void Done()
    {
        if(_state == 5)
        {
            _anak.sprite = _anakSenang;
            _butuhGaButuh.StopAnyRunningCoroutine();
        }
    }
}
