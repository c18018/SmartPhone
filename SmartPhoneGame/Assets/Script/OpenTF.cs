using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTF : MonoBehaviour {

    public GameObject openObj;
    public GameObject spObj;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == spObj)
        {
            openObj.gameObject.layer = 9;
            Invoke("reLayer", 0.5f);
        }
    }
}
