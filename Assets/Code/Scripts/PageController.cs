using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DhafinFawwaz.Tweener;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class PageController : MonoBehaviour
{
    static int _pageFromIndex = -1;
    public static void SetStartingPage(int index)
    {
        _pageFromIndex = index;
    }


    int _currentPage = -1;
    int _pageAmount = 0;

    public UnityEvent OnNextInLastPage;

    [SerializeField] VideoPlayer[] _videoPlayers;

    [SerializeField] SceneTransition _sceneTransition;
    [SerializeField] int[] _delayedPages;
    [SerializeField] int[] _minigamePages;
    [SerializeField] ButtonUI _nextButton;
    bool _isDelayFinished;
    public void SetDelayFinished(bool isFinished)
    {
        _isDelayFinished = isFinished;
    }

    public Action<int> OnPageDelayed;

    [SerializeField] ImageTweener _blackTweener;
    [SerializeField] List<GameObject> _pageCopies;

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

        Transform[] children = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            children[i] = transform.GetChild(i);
        foreach(Transform child in children) {
            GameObject copy = Instantiate(child.gameObject);
            copy.SetActive(false);
            _pageCopies.Add(copy);
        }

        yield return new WaitForSeconds(0.5f);

        StartCoroutine(_sceneTransition.InAnimation());


        if(_pageFromIndex != -1)
        {
            transform.GetChild(_pageFromIndex).gameObject.SetActive(true);
            _currentPage = _pageFromIndex;
            _pageFromIndex = -1;
        } 
        else
        {
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

    void ResetCurrentPage()
    {
        GameObject copy = Instantiate(_pageCopies[_currentPage], transform);
        Destroy(transform.GetChild(_currentPage).gameObject);
        copy.transform.SetSiblingIndex(_currentPage+1);
    }

    public void ChangePage(int page)
    {   
        if(!_delayedPages.Contains(_currentPage) && _currentPage != 0) ResetCurrentPage();
    

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

        if(_minigamePages.Contains(page)) {
            _nextButton.SetInteractableImmediete(false);
        } else {
            _nextButton.SetInteractableImmediete(true);
        }
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


#if UNITY_EDITOR
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextPage();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousPage();
        }
    }
#endif
}
