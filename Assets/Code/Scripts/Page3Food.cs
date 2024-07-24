using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Page3Food : MonoBehaviour
{
    [SerializeField] UnityEvent<int> _onTapped;    
    public void Click()
    {
        for(int i = 0; i < transform.childCount; i++) {
            if(transform.GetChild(i).gameObject.activeInHierarchy) {
                if(i == transform.childCount-1) {
                    _onTapped?.Invoke(i+1);
                } else {
                    transform.GetChild(i).gameObject.SetActive(false);
                    transform.GetChild(i+1).gameObject.SetActive(true);
                    _onTapped?.Invoke(i);
                }
                break;
            }
        }
    }
}
