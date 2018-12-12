using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    bool moveOn;
    public float speed;
    float limitZ;
    public GameObject model;

    void Start () {
        moveOn = true;
    }
	
	void Update () {
        if (moveOn) playerMove();
	}

    void playerMove()
    {
        transform.Translate(Time.deltaTime * speed, 0, 0);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            moveOn = false;
            model.SendMessage("AniF");
        }
    }

    void moveF()
    {
        moveOn = false;
        model.SendMessage("AniF");
    }
}
