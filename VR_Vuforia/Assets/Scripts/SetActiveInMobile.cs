using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveInMobile : MonoBehaviour
{
    public bool activeInMobile;

    void Awake()
    {
#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)
        gameObject.SetActive(activeInMobile);
#else
        gameObject.SetActive(!activeInMobile);
#endif
    }
}
