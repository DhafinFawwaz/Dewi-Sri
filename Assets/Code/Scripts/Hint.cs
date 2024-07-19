using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{   
    bool _isOn;
    [SerializeField] GameObject _hintEffect;
    void OnEnable()
    {
        _isOn = PlayerPrefs.GetInt("Hint", 1) == 1 ? true : false;
        _hintEffect.SetActive(_isOn);
    }
}
