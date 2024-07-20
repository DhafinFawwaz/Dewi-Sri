using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Page3Manager : MonoBehaviour
{
    [SerializeField] GameObject[] _expresi;
    // normal
    // makan
    // gasuka
    // geleng
    // geleng
    [SerializeField] GameObject[] _nasi;
    [SerializeField] GameObject[] _ikan;
    [SerializeField] GameObject[] _sayurAsem;
    [SerializeField] GameObject[] _tahuTempe;
    [SerializeField] GameObject _clickable;
    [SerializeField] UnityEvent _onFinish;

    int _state = 0;
    public void NextState()
    {
        if(_state == 0) StartCoroutine(Tap1Animation());
        else if(_state == 1) StartCoroutine(Tap2Animation());
        else if(_state == 2) StartCoroutine(Tap3Animation());
        else if(_state == 3) StartCoroutine(Tap4Animation());

        if(_state == 2) {
            _state++;
            return;
        }
        if(_state == 3) return;
        
        _nasi[_state].SetActive(false);
        _ikan[_state].SetActive(false);
        _sayurAsem[_state].SetActive(false);
        _tahuTempe[_state].SetActive(false);
        _state++;
        _nasi[_state].SetActive(true);
        _ikan[_state].SetActive(true);
        _sayurAsem[_state].SetActive(true);
        _tahuTempe[_state].SetActive(true);
    }

    public void ResetState()
    {
        _state = 0;
        _clickable.SetActive(true);

        for(int i = 0; i < _expresi.Length; i++) _expresi[i].SetActive(false);
        for(int i = 0; i < _nasi.Length; i++) _nasi[i].SetActive(false);
        for(int i = 0; i < _ikan.Length; i++) _ikan[i].SetActive(false);
        for(int i = 0; i < _sayurAsem.Length; i++) _sayurAsem[i].SetActive(false);
        for(int i = 0; i < _tahuTempe.Length; i++) _tahuTempe[i].SetActive(false);

        _expresi[0].SetActive(true);
        _nasi[0].SetActive(true);
        _ikan[0].SetActive(true);
        _sayurAsem[0].SetActive(true);
        _tahuTempe[0].SetActive(true);
    }

    void SetExpresi(int _idx)
    {
        for(int i = 0; i < _expresi.Length; i++)
            _expresi[i].SetActive(false);
        _expresi[_idx].SetActive(true);
    }

    [SerializeField] float _one = 0.6f;
    IEnumerator Tap1Animation()
    {
        _clickable.SetActive(false);
        SetExpresi(1);
        yield return new WaitForSeconds(_one);
        SetExpresi(0);
        yield return new WaitForSeconds(0.3f);
        _clickable.SetActive(true);
    }

    IEnumerator Tap2Animation()
    {
        _clickable.SetActive(false);
        SetExpresi(1);
        yield return new WaitForSeconds(_one);
        SetExpresi(2);
        yield return new WaitForSeconds(_one);
        SetExpresi(0);
        yield return new WaitForSeconds(0.3f);
        _clickable.SetActive(true);
    }

    IEnumerator Tap3Animation()
    {
        _clickable.SetActive(false);
        SetExpresi(1);
        yield return new WaitForSeconds(_one);
        SetExpresi(3);
        yield return new WaitForSeconds(0.2f);
        SetExpresi(4);
        yield return new WaitForSeconds(0.2f);
        SetExpresi(3);
        yield return new WaitForSeconds(0.2f);
        SetExpresi(4);
        yield return new WaitForSeconds(_one);
        SetExpresi(0);
        yield return new WaitForSeconds(0.3f);
        _clickable.SetActive(true);
    }

    IEnumerator Tap4Animation()
    {
        _clickable.SetActive(false);
        SetExpresi(3);
        yield return new WaitForSeconds(0.2f);
        SetExpresi(4);
        yield return new WaitForSeconds(0.2f);
        SetExpresi(3);
        yield return new WaitForSeconds(0.2f);
        SetExpresi(4);
        yield return new WaitForSeconds(_one);
        SetExpresi(0);
        yield return new WaitForSeconds(0.3f);
        _clickable.SetActive(true);

        _onFinish?.Invoke();
    }

}
