using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{   
    public static Action S_OnHintChanged;

    bool _isOn;
    bool _forcedOn = false;

    public void SetForcedOn(bool forcedOn)
    {
        _forcedOn = forcedOn;
        Refresh();
    }

    [SerializeField] GameObject _hintEffect;
    void Awake()
    {
        // _hintEffect.SetActive(false);
        StartCoroutine(DelayCallback(0.1f, () => _hintEffect.SetActive(true)));
    }

    IEnumerator DelayCallback(float delay, System.Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback();
    }
    
    void OnEnable()
    {
        Refresh();
        S_OnHintChanged += Refresh;
    }

    void Refresh()
    {
        _isOn = PlayerPrefs.GetInt("Hint", 1) == 1 ? false : true;
        _hintEffect.SetActive(_isOn && _forcedOn);
    }

    void OnDisable()
    {
        S_OnHintChanged -= Refresh;
    }
}
