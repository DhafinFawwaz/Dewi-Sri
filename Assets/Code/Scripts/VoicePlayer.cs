using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DhafinFawwaz.Tweener;
using UnityEngine.Events;

public class VoicePlayer : MonoBehaviour
{
    [SerializeField] VoiceTiming[] _timings;
    [SerializeField] AudioSource _source;
    [SerializeField] UnityEvent _onMusicEnd;
    [SerializeField] float _delayOffset = 0;

    void OnEnable()
    {
        Play();
    }

    public void Play()
    {
        _source.Play();
        StartCoroutine(DelayCallback(_source.clip.length+_delayOffset, () => _onMusicEnd?.Invoke()));
        foreach (var timing in _timings)
        {
            StartCoroutine(PlayText(timing));
        }
    }

    IEnumerator DelayCallback(float delay, System.Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback();
    }

    IEnumerator PlayText(VoiceTiming timing)
    {
        yield return new WaitForSeconds(timing.Time);
        timing.Tweener.Text();
    }

    [ContextMenu("Auto Assign Timing")]
    public void AutoAssignTiming()
    {
        List<VoiceTiming> timings = new List<VoiceTiming>();
        foreach(Transform child in transform.parent)
        {
            if(child.TryGetComponent(out TextMeshProTweener tweener))
            {
                timings.Add(new VoiceTiming(0, tweener));
            }
        }
        _timings = timings.ToArray();
    }
}

[Serializable] class VoiceTiming
{
    [SerializeField] float _time;
    public float Time => _time;
    [SerializeField] TextMeshProTweener _tweener;
    public TextMeshProTweener Tweener => _tweener;

    public VoiceTiming(float time, TextMeshProTweener tweener)
    {
        _time = time;
        _tweener = tweener;
    }
}
