using System.Collections;
using System.Collections.Generic;
using DhafinFawwaz.Tweener;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageManager : MonoBehaviour
{
    [SerializeField] SceneTransition _sceneTransition;
    static int _pageFromIndex = -1;
    public static void SetStartingPage(int index)
    {
        _pageFromIndex = index;
    }

    int _currentPage = -1;
    [SerializeField] int _pageAmount = 26;
    [SerializeField] string _mainMenuScene = "MainMenu";

    [Header("Special Case")]
    [SerializeField] bool _isMiniGame = false;
    [SerializeField] ButtonUI _nextButton;
    [SerializeField] ImageTweener _blackTweener;
    void Awake()
    {
        if(_pageFromIndex == -1)
            _currentPage = int.Parse(SceneManager.GetActiveScene().name);
        else {
            _currentPage = _pageFromIndex;
            _pageFromIndex = -1;
        }
    }

    public void ChangePage(int page)
    {
        if(page < 0 || page >= _pageAmount)
        {
            SceneManager.LoadScene(_mainMenuScene);
            return;
        }
        _sceneTransition.StartSceneTransition(page.ToString());
    }

    public void NextPage()
    {
        ChangePage(_currentPage + 1);
    }

    public void PreviousPage()
    {
        ChangePage(_currentPage - 1);
    }

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
