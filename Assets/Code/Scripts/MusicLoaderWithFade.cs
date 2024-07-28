using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicLoaderWithFade : MonoBehaviour
{
    [SerializeField] AudioClip _musicClip;
    [SerializeField] bool _isLooping = true;
    void OnEnable() => StartCoroutine(DelayOnEnable());

    IEnumerator DelayOnEnable()
    {
        while(!Audio.IsInitialized)
        {
            Debug.Log("Audio isn't initialized yet");
            yield return null;
        }
        // Audio.SetMusicSourceVolume(1);
        if(_musicClip == Audio.GetCurrentMusicClip()) // Same music
        {
            // Audio.ToggleLoop(true);
        }
        else if(_musicClip != null) // Different music
        {
            Audio.PlayMusic(_musicClip);
            ApplyFading();
        }
    }


    [SerializeField] float _fadeDuration = 2f;
    void ApplyFading()
    {
        Audio.MusicFadeIn(_fadeDuration);
        StartCoroutine(DelayCallback(Audio.GetCurrentMusicClip().length-_fadeDuration, () => {
            Audio.MusicFadeOut(_fadeDuration);
            StartCoroutine(DelayCallback(_fadeDuration, () => {
                Audio.StopMusic();
                Audio.PlayMusic(_musicClip);
                ApplyFading();
            }));
        }));
    }


    IEnumerator DelayCallback(float delay, System.Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback();
    }
    
    public void FadeOutMusic()
    {
        Audio.MusicFadeOut(0.5f);
    }
}
