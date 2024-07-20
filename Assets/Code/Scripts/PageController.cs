using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DhafinFawwaz.Tweener;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class PageController : MonoBehaviour
{
    int _currentPage = -1;
    int _pageAmount = 0;

    public UnityEvent OnNextInLastPage;

    [SerializeField] VideoPlayer[] _videoPlayers;

    [SerializeField] SceneTransition _sceneTransition;
    [SerializeField] int[] _delayedPages;
    bool _isDelayFinished;
    public void SetDelayFinished(bool isFinished)
    {
        _isDelayFinished = isFinished;
    }

    public Action<int> OnPageDelayed;

    [SerializeField] ImageTweener _blackTweener;

    void ShowBlack()
    {
        _blackTweener.gameObject.SetActive(true);
        _blackTweener.SetEndColor(new Color(0,0,0,1)).Color();
    }

    void HideBlack()
    {
        _blackTweener.SetEndColor(new Color(0,0,0,0)).Color();
        _blackTweener.OnceDone(() => _blackTweener.gameObject.SetActive(false));
    }

    void Awake()
    {
        _sceneTransition.gameObject.SetActive(true);
        _pageAmount = transform.childCount;
        StartCoroutine(Init());
    }

    IEnumerator Init()
    {
        // while(_videoPlayers.Any(x => !x.isPrepared))
        // {
        //     yield return new WaitForSecondsRealtime(0.1f);
        // }

        StartCoroutine(_sceneTransition.InAnimation());

        for (int i = _pageAmount-1; i >= 0; i--)
        {
            if(transform.GetChild(i).gameObject.activeInHierarchy)
            {
                _currentPage = i;
                break;
            }
        }
        if(_currentPage == -1)
        {
            _currentPage = 0;
            transform.GetChild(_currentPage).gameObject.SetActive(true);
        }
        yield return null;
    }

    public void NextPage()
    {
        ChangePage(_currentPage + 1);
    }
    public void PreviousPage()
    {
        ChangePage(_currentPage - 1);
    }

    void ChangePage(int page)
    {
        if(page >= _pageAmount) {
            OnNextInLastPage?.Invoke();
            return;
        }

        if(page < 0) return;
        if(_delayedPages.Contains(page))
        {
            StartCoroutine(DelayedToPage(page));
            return;
        }
        ImmediateToPage(page);
    }

    void ImmediateToPage(int page)
    {
        ShowBlack();
        _blackTweener.OnceDone(() => {
            transform.GetChild(_currentPage).gameObject.SetActive(false);
            _currentPage = page;
            transform.GetChild(_currentPage).gameObject.SetActive(true);
            HideBlack();
        });
    }

    IEnumerator DelayedToPage(int page)
    {
        ShowBlack();
        bool isBlackTweenerDone = false;
        _blackTweener.OnceDone(() => {
            isBlackTweenerDone = true;
        });

        _isDelayFinished = false;
        OnPageDelayed?.Invoke(page);
        while(!_isDelayFinished) yield return null;
        while(!isBlackTweenerDone) yield return null;

        HideBlack();
        
        transform.GetChild(_currentPage).gameObject.SetActive(false);
        _currentPage = page;
        transform.GetChild(_currentPage).gameObject.SetActive(true);
    }

}
