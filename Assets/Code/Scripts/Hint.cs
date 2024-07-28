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
        _hintEffect.SetActive(false);
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
