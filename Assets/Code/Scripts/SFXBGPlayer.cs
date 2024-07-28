using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXBGPlayer : MonoBehaviour
{
    [SerializeField] AudioSource _source;
    [SerializeField] float _delayOffset = 0;

    void OnEnable()
    {
        StartCoroutine(DelayCallback(_delayOffset, () => {
            _source.Play();
        }));
    }
    IEnumerator DelayCallback(float delay, System.Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback();
    }
}
