using System.Collections;
using System.Collections.Generic;
using DhafinFawwaz.Tweener;
using UnityEngine;

public class ButuhGaButuh : MonoBehaviour
{
    [SerializeField] TransformTweener _showTweener;
    [SerializeField] TextMeshProTweener _butuh;
    [SerializeField] TextMeshProTweener _gaButuh;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Sprite[] _sprites;
    Coroutine _coroutine;
    public void SetButuh()
    {
        _showTweener.LocalScale();
        _butuh.gameObject.SetActive(true);
        _butuh.Text();
        _gaButuh.gameObject.SetActive(false);
        _spriteRenderer.sprite = _sprites[1];
        if(_coroutine != null) StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(DelayCallback(1f, () => _spriteRenderer.sprite = _sprites[0]));
    }

    public void SetGaButuh()
    {
        _showTweener.LocalScale();
        _gaButuh.gameObject.SetActive(true);
        _gaButuh.Text();
        _butuh.gameObject.SetActive(false);
        _spriteRenderer.sprite = _sprites[2];
        if(_coroutine != null) StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(DelayCallback(1f, () => _spriteRenderer.sprite = _sprites[0]));
    }

    public void StopAnyRunningCoroutine()
    {
        if(_coroutine != null) StopCoroutine(_coroutine);
    }

    IEnumerator DelayCallback(float delay, System.Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback();
    }
}
