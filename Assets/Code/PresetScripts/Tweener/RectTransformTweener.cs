using Unity.VisualScripting;
using UnityEngine;

namespace DhafinFawwaz.Tweener
{
    public class RectTransformTweener : Tweener
    {
        [Header("Values")]
        [SerializeField] RectTransform _target;
        [SerializeField] Vector3 _end;
        Coroutine[] _coroutines = new Coroutine[3];

        public RectTransformTweener SetEnd(Vector3 end)
        {
            _end = end;
            return this;
        }

        public override void Stop()
        {
            foreach (var c in _coroutines) StopCoroutineIfNotNull(c);
        }

        [ContextMenu("Play AnchoredPosition")]
        public void AnchoredPosition()
        {
            StopCoroutineIfNotNull(_coroutines[2]);
            _coroutines[2] = TweenIfActive<Vector3>(
                x => _target.anchoredPosition = x,
                _target.anchoredPosition,
                _end,
                _duration,
                Vector3.LerpUnclamped
            );
        }

        [ContextMenu("Play LocalPosition")]
        public void LocalPosition()
        {
            StopCoroutineIfNotNull(_coroutines[2]);
            _coroutines[2] = TweenIfActive<Vector3>(
                x => _target.localPosition = x,
                _target.localPosition,
                _end,
                _duration,
                Vector3.LerpUnclamped
            );
        }

        [ContextMenu("Play EulerAngles")]
        public void EulerAngles()
        {
            StopCoroutineIfNotNull(_coroutines[1]);
            _coroutines[1] = TweenIfActive<Vector3>(
                x => _target.eulerAngles = x,
                _target.eulerAngles,
                _end,
                _duration,
                Vector3.LerpUnclamped
            );
        }

        [ContextMenu("Play LocalEulerAngles")]
        public void LocalEulerAngles()
        {
            StopCoroutineIfNotNull(_coroutines[1]);
            _coroutines[1] = TweenIfActive<Vector3>(
                x => _target.localEulerAngles = x,
                _target.localEulerAngles,
                _end,
                _duration,
                Vector3.LerpUnclamped
            );
        }

        [ContextMenu("Play LocalScale")]
        public void LocalScale()
        {
            StopCoroutineIfNotNull(_coroutines[0]);
            _coroutines[0] = TweenIfActive<Vector3>(
                x => _target.localScale = x,
                _target.localScale,
                _end,
                _duration,
                Vector3.LerpUnclamped
            );
        }

    }

}
