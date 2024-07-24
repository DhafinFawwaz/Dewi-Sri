using System.Collections;
using System.Collections.Generic;
using DhafinFawwaz.Tweener;
using UnityEngine;

public class LetterAnimation : MonoBehaviour
{
    [SerializeField] TransformTweener[] _tweener;

    [ContextMenu("Play")]
    public void Play()
    {
        _tweener[0].LocalScale();
        _tweener[1].LocalEulerAngles();
        _tweener[2].LocalPosition();
    }
}
