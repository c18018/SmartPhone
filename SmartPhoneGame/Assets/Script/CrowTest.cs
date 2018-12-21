using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowTest : MonoBehaviour {

    Vector3 playerPos;
    Vector3 myRote;
    public float rate;
    //bool moveTF;
    int crowChiled;

    float offset = 0;

    int count;

    private void Start()
    {
        //moveTF = true;
        Search();
        myRote = (playerPos - transform.position);
        transform.rotation = Quaternion.FromToRotation(Vector3.up, myRote);
        Imove();

    }

    private void Update()
    {
        if (count > 30)
        {
            Search();
            count = 0;
        }

        count++;
        
         Imove();

        if(playerPos.x > transform.position.x + 100.0f)
        {
            Destroy(gameObject);
        }
    }

    void Search()
    {
        playerPos = GameObject.FindWithTag("Player").transform.position;
        offset = Random.Range(0, 94);
        playerPos = new Vector3(playerPos.x + offset, playerPos.y + offset, playerPos.z);
    }



    void Imove()
    {
        transform.position = Vector3.Lerp(transform.position, playerPos, rate);
    }

    /*private void OnTriggerStay2D (Collider2D collision)
    {
        if(collision.gameObject.tag == "CrowTF")
        {
            moveTF = false;
        }
    }*/
}
