using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Page16Manager : MonoBehaviour
{
    [SerializeField] GameObject[] _clickables;
    [SerializeField] UnityEvent _onFinish;

    bool _isFinished = false;
    public void ResetState()
    {
        _isFinished = false;
        foreach(var c in _clickables) c.SetActive(true);
    }
    void Update()
    {
        if(_isFinished) return;
        if(_clickables.All(c => !c.activeInHierarchy))
        {
            _isFinished = true;
            StartCoroutine(DelayCallback(0.5f, _onFinish));
        }
    }

    IEnumerator DelayCallback(float delay, UnityEvent callback)
    {
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
    }
}
