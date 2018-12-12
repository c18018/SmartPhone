using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowCall : MonoBehaviour
{
    bool coll;
    public GameObject InsObj;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            coll = true;
        }
    }

    private void Update()
    {
        if (coll)
        {
            Invoke("TimeLag", 2.0f);
        }
    }

    void TimeLag()
    {
        InsObj.SendMessage("Appear");
        Destroy(gameObject);
    }
}
