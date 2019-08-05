using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowCall : MonoBehaviour
{
    bool coll;
    public GameObject crowins;


    // プレイヤーがぶつかったらカラスを呼ぶ
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            coll = true;
        }
    }


    // プレイヤーぶつかってから２秒後にカラスを生成
    private void Update()
    {
        if (coll)
        {
            Invoke("TimeLag", 2.0f);
        }
    }

    void TimeLag()
    {
        crowins.SendMessage("insTF");
        Destroy(gameObject);
    }
}
