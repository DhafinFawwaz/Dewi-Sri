using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{   
    public static Action S_OnHintChanged;

    bool _isOn;
    [SerializeField] GameObject _hintEffect;
    void OnEnable()
    {
        Refresh();
        S_OnHintChanged += Refresh;
    }

    void Refresh()
    {
        _isOn = PlayerPrefs.GetInt("Hint", 1) == 1 ? false : true;
        _hintEffect.SetActive(_isOn);
    }

    void OnDisable()
    {
        S_OnHintChanged -= Refresh;
    }
}
