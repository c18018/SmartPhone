using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{

    Vector3 playerPos;
    Vector3 myRote;
    public float rate;
    bool moveTF;
    int crowChiled;

    private void Start()
    {
        moveTF = true;
    }


    void Update()
    {
        if (moveTF)
        {
            Imove();
        }

        if(transform.childCount == 0)
        {
            Destroy(gameObject);
        }

    }

    void Imove()
    {
        playerPos = GameObject.FindWithTag("Player").transform.position;
        myRote = (playerPos - transform.position);
        transform.rotation = Quaternion.FromToRotation(Vector3.up, myRote);

        transform.position = Vector3.Lerp(transform.position, playerPos, rate);
    }

    public void crowMove()
    {
        moveTF = false;
    }
}
