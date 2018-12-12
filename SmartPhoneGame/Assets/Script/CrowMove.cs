using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowMove : MonoBehaviour {

    public GameObject crow;

    void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            crow.SendMessage("crowMove");
        } 
    }
}
