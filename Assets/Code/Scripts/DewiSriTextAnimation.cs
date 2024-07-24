using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DewiSriTextAnimation : MonoBehaviour
{
    [SerializeField] LetterAnimation[] _letters;
    [SerializeField] float _delay = 0.3f;

    [ContextMenu("Play")]
    public void Play()
    {
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        foreach (var l in _letters)
        {
            l.Play();
            yield return new WaitForSeconds(_delay);
        }
    }
}
