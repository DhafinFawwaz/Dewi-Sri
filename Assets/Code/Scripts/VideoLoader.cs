using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoLoader : MonoBehaviour
{
    [SerializeField] VideoPlayer _videoPlayer;
    [SerializeField] string _video;
    [SerializeField] float _delay = 0;
    void Start()
    {
        if(!enabled) return;
        Debug.Log("Loading video");
        transform.localScale = Vector3.one;
        StartCoroutine(DelayCallback(_delay, () => {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, _video);
            Debug.Log(videoPath);
            _videoPlayer.url = videoPath;
            _videoPlayer.enabled = true;
            _videoPlayer.Play();
        }));
    }

    IEnumerator DelayCallback(float delay, System.Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback();
    }
}
