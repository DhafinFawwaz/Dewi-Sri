using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Page16Manager : MonoBehaviour
{
    [SerializeField] GameObject[] _clickables;
    [SerializeField] UnityEvent _onFinish;
    [SerializeField] UnityEvent _onExactFinish;
    [SerializeField] float _finishDelay = 1;

    bool _isFinished = false;
    bool _isStarted = false;
    public void StartGame()
    {
        _isStarted = true;
    }
    public void ResetState()
    {
        _isFinished = false;
        foreach(var c in _clickables) c.SetActive(true);
    }
    void Update()
    {
        if(!_isStarted) return;
        if(_isFinished) return;
        if(_clickables.All(c => !c.activeInHierarchy))
        {
            _isFinished = true;
            _onExactFinish?.Invoke();
            StartCoroutine(DelayCallback(_finishDelay, _onFinish));
        }
    }

    IEnumerator DelayCallback(float delay, UnityEvent callback)
    {
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
    }
}
