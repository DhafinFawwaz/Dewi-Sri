using Unity.VisualScripting;
using UnityEngine;

namespace DhafinFawwaz.Tweener
{
    public class MaterialTweener : Tweener
    {
        [Header("Values")]
        [SerializeField] Material _target;
        [SerializeField] string _property;
        [SerializeField] Color _end;
        Coroutine[] _coroutines = new Coroutine[1];

        public override void Stop()
        {
            foreach (var c in _coroutines) StopCoroutineIfNotNull(c);
        }

        [ContextMenu("Play Color")]
        public void Color()
        {
            StopCoroutineIfNotNull(_coroutines[0]);
            _coroutines[0] = TweenIfActive(
                x => _target.SetColor(_property, x),
                _target.GetColor(_property),
                _end,
                _duration,
                UnityEngine.Color.LerpUnclamped
            );
        }


#if UNITY_EDITOR
        void Reset()
        {
            _target = transform.GetComponent<Renderer>().material;
        }
#endif
    }

}
