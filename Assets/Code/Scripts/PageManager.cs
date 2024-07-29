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

        if(_isMiniGame) DisableNextButton();
    }

    public void ChangePage(int page)
    {
        if(page <= 0 || page > _pageAmount)
            _sceneTransition.StartSceneTransition(_mainMenuScene);
        else _sceneTransition.StartSceneTransition(page.ToString());
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

    public void GoHome()
    {
        _sceneTransition.StartSceneTransition(_mainMenuScene);
    }

    void DisableNextButton()
    {
        _nextButton.SetInteractableImmediete(false);
    }

    public void EnableNextButton()
    {
        _nextButton.SetInteractableImmediete(true);
        _nextButton.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
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

        if(Input.GetKeyDown(KeyCode.F7))
        {
            Time.timeScale = 5;
        }
        else if(Input.GetKeyUp(KeyCode.F7))
        {
            Time.timeScale = 1;
        }
    }
#endif
}
