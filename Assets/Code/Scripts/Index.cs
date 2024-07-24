using System.Collections;
using System.Collections.Generic;
using DhafinFawwaz.Tweener;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Index : MonoBehaviour
{
    [SerializeField] Transform _buttonParent;
    [SerializeField] float _delay = 0.2f;
    [SerializeField] Sprite[] _images;
    [SerializeField] CanvasGroupTweener _canvasGroupTweener;
    [SerializeField] protected SceneTransition _sceneTransition;
    [SerializeField] PageController _pageController;

    public void Show()
    {
        gameObject.SetActive(true);
        _canvasGroupTweener.SetEnd(1).Alpha();
        int _currentPage = 0;
        foreach(Transform child in _buttonParent) {
            Image img = child.transform.GetChild(0).GetChild(0).GetComponent<Image>();
            img.sprite = _images[_currentPage];
            Vector2 size = img.rectTransform.sizeDelta;
            img.SetNativeSize();
            float percentage = size.y / img.rectTransform.sizeDelta.y;
            // Same height as size
            img.rectTransform.sizeDelta = new Vector2(img.rectTransform.sizeDelta.x*percentage, size.y);
            
            _currentPage++;
            ButtonUI button = child.GetComponent<ButtonUI>();
            int page = _currentPage-1;

            if(_pageController == null) {
                button.OnClick.AddListener(() => {
                    LoadPage(page);
                });
            } else {
                button.OnClick.AddListener(() => {
                    _pageController.ChangePage(page);
                    Hide();
                });
            }

            TransformTweener tweener = child.GetComponent<TransformTweener>();
            child.GetChild(0).localScale = Vector3.zero;
            StartCoroutine(DelayCallback(_currentPage*_delay, () => {
                tweener.LocalScale();
            }));
        }
    }

    public void Hide()
    {
        _canvasGroupTweener.SetEnd(0).Alpha();
        _canvasGroupTweener.OnceDone(() => gameObject.SetActive(false));
    }

    IEnumerator DelayCallback(float delay, System.Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback();
    }

    [SerializeField] string _sceneName = "Game";
    protected virtual void LoadPage(int page)
    {
        PageController.SetStartingPage(page);
        _sceneTransition.StartSceneTransition(_sceneName);
    }
}
