using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextCopier : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
    [ContextMenu("Copy Text")]
    public void CopyText()
    {
        TMP_Text thisText = GetComponent<TMP_Text>();
        thisText.text = _text.text;
        thisText.fontSize = _text.fontSize;
        thisText.color = _text.color;
        
        RectTransform thisRt = GetComponent<RectTransform>();
        RectTransform textRt = _text.GetComponent<RectTransform>();
        thisRt.sizeDelta = textRt.sizeDelta;
        thisRt.anchoredPosition = textRt.anchoredPosition;
        thisRt.anchorMin = textRt.anchorMin;
        thisRt.anchorMax = textRt.anchorMax;
        thisRt.pivot = textRt.pivot;
        thisRt.localScale = textRt.localScale;

        thisText.alignment = _text.alignment;
        thisText.font = _text.font;

        thisText.enableWordWrapping = _text.enableWordWrapping;
        thisText.overflowMode = _text.overflowMode;
        thisText.richText = _text.richText;
        thisText.raycastTarget = _text.raycastTarget;
        thisText.enableAutoSizing = _text.enableAutoSizing;
        thisText.fontSizeMin = _text.fontSizeMin;
        thisText.fontSizeMax = _text.fontSizeMax;
        thisText.lineSpacing = _text.lineSpacing;
        thisText.characterSpacing = _text.characterSpacing;
        thisText.wordSpacing = _text.wordSpacing;
        thisText.paragraphSpacing = _text.paragraphSpacing;
        thisText.characterWidthAdjustment = _text.characterWidthAdjustment;
        
    }
}
