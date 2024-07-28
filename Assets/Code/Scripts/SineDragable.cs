using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineDragable : MonoBehaviour
{
    [SerializeField] LineRenderer _line;
    [SerializeField] Transform _circle;

    [SerializeField] float _length = 1;
    [SerializeField] float _duration = 0.5f;
    [SerializeField] Color _lineStartColor = new Color(1,1,1,0.8f);

    void Awake()
    {
        StartCoroutine(Tween());
    }
    

    IEnumerator Tween()
    {
        Color endColor = new Color(0,0,0,0);
        while(true)
        {
            float t = 0;
            Vector3 start = _circle.localPosition;
            Vector3 end = _circle.localPosition + new Vector3(_length, _length);
            while (t < 1)
            {
                t += Time.deltaTime/_duration;
                _circle.localPosition = Vector3.Lerp(start, end, EaseInOutQuad(t));
                _line.SetPosition(0, start);
                _line.SetPosition(1, _circle.localPosition);
                _line.startColor = Color.Lerp(_lineStartColor, endColor, EaseInOutQuad(t));
                _line.endColor = _line.startColor;
                yield return null;
            }
            _circle.localPosition = end;
            _line.SetPosition(0, end);
            _line.SetPosition(1, _circle.localPosition);

            t = 0;
            start = _circle.localPosition;
            end = _circle.localPosition - new Vector3(_length, _length);
            while (t < 1)
            {
                t += Time.deltaTime/_duration;
                _circle.localPosition = Vector3.Lerp(start, end, EaseInOutQuad(t));
                _line.SetPosition(0, start);
                _line.SetPosition(1, _circle.localPosition);
                _line.startColor = Color.Lerp(_lineStartColor, endColor, EaseInOutQuad(t));
                _line.endColor = _line.startColor;
                yield return null;
            }
        }
    }

    float EaseInOutSine(float x) {
        return -(Mathf.Cos(Mathf.PI * x) - 1) / 2;
    }    

    float EaseInOutQuart(float x) {
        return x < 0.5 ? 8 * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 4) / 2;
    }

    float EaseInOutQuad(float x) {
        return x < 0.5 ? 2 * x * x : 1 - Mathf.Pow(-2 * x + 2, 2) / 2;
    }

    float EaseInOutCubic(float x) {
        return x < 0.5 ? 4 * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 3) / 2;
    }

    float EaseInOutCircle(float x) {
        return x < 0.5 ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * x, 2))) / 2 : (Mathf.Sqrt(1 - Mathf.Pow(-2 * x + 2, 2)) + 1) / 2;
    }
}
