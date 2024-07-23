using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoLoader : MonoBehaviour
{
    [SerializeField] VideoPlayer _videoPlayer;
    [SerializeField] string _video;
    void Start()
    {
        if(!enabled) return;
        Debug.Log("Loading video");
        StartCoroutine(DelayCallback(1, () => {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, _video);
            Debug.Log(videoPath);
            _videoPlayer.url = videoPath;
        }));
    }

    IEnumerator DelayCallback(float delay, System.Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback();
    }
}
