using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAsChildMobile : MonoBehaviour
{
    [Tooltip("GameObjects that are gonna be set as childs of this gameObject")]
    public GameObject[] childs;

    // Start is called before the first frame update
    void Awake()
    {
#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)
        foreach(GameObject g in childs)
        {
            g.transform.SetParent(transform);
        }
#else
        Destroy(this);
#endif
    }
}
