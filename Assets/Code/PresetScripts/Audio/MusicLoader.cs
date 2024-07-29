using System.Collections;
using UnityEngine;

public class MusicLoader : MonoBehaviour
{
    [SerializeField] AudioClip _musicClip;
    [SerializeField] bool _isLooping = true;
    [SerializeField] bool _playWithSFXSource = false;
    void OnEnable() => StartCoroutine(DelayOnEnable());

    IEnumerator DelayOnEnable()
    {
        while(!Audio.IsInitialized)
        {
            Debug.Log("Audio isn't initialized yet");
            yield return null;
        }
        if(_playWithSFXSource) Audio.SetMusicSourceVolumeWithSFX(0);
        else {
            // Audio.SetMusicSourceVolume(1);
            Audio.MusicFadeIn(2f);
        }
        if(_musicClip == Audio.GetCurrentMusicClip()) // Same music
        {
            if(_playWithSFXSource) Audio.ToggleLoopWithSFX(true);
            else Audio.ToggleLoop(true);
        }
        else if(_musicClip != null) // Different music
        {
            if(_playWithSFXSource) {
                Audio.ToggleLoopWithSFX(_isLooping);
                Audio.PlayMusicWithSFX(_musicClip);
            }
            else {
                Audio.ToggleLoop(_isLooping);
                Audio.PlayMusic(_musicClip);
            }
        }
        else // No music
        {
            if(_playWithSFXSource) {
                Audio.ToggleLoopWithSFX(true);
                Audio.StopMusicWithSFX();
            } else {
                Audio.ToggleLoop(true);
                Audio.StopMusic();
            }
        }
    }
    
    public void FadeOutMusic()
    {
        Audio.MusicFadeOut(0.5f);
    }
}
