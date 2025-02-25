using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoPreparer : MonoBehaviour
{
    [SerializeField] VideoPlayer _videoPlayer;
    [SerializeField] UnityEvent _onPrepared;
    [SerializeField] PageController _pageController;
    [SerializeField] int _pageToPrepare;
    [SerializeField] GameObject _inputBlocker;

    void Awake()
    {
        // _videoPlayer.Prepare();
    }


    void OnEnable()
    {
        _pageController.OnPageDelayed += OnPageDelayed;
    }

    void OnDisable()
    {
        _pageController.OnPageDelayed -= OnPageDelayed;
    }

    void OnPageDelayed(int page)
    {
        if(page == _pageToPrepare)
        {
            StartCoroutine(Prepare());
        }
    }


    IEnumerator Prepare()
    {
        _inputBlocker.SetActive(true);

        // if(_firstTime && _videoPlayer.isPrepared)
        // {
        //     _firstTime = false;
        //     _onPrepared?.Invoke();
        //     Debug.Log("First time prepared");
        //     _videoPlayer.Play();
        //     _inputBlocker.SetActive(false);
        // }
        // else
        // {
            yield return new WaitForSeconds(1);
            _videoPlayer.gameObject.SetActive(false);
            yield return null;
            _videoPlayer.gameObject.SetActive(true);

            _videoPlayer.Prepare();
            while(!_videoPlayer.isPrepared) yield return null;
            _onPrepared?.Invoke();

            yield return null;
            _videoPlayer.Play();

            
            _inputBlocker.SetActive(false);
        // }
    }
}
