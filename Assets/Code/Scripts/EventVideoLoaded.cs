using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class EventVideoLoaded : MonoBehaviour
{
    [SerializeField] VideoPlayer _videoPlayer;
    [SerializeField] UnityEvent _onVideoLoaded;
    void Start()
    {
        StartCoroutine(WaitUntilVideoPlay());
    }

    IEnumerator WaitUntilVideoPlay()
    {
        yield return new WaitUntil(() => _videoPlayer.isPlaying && _videoPlayer.isPrepared && _videoPlayer.frame > 0);
        _onVideoLoaded.Invoke();
    }
}
