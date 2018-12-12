using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

    public float parcent;
    Vector3 balloonScale;
    Vector3 PerTime;
    bool shrink = false;
    bool balloonShot;
    
	void Start () {
        transform.localRotation = Quaternion.Euler(0, 0, 180);
	}
	
	void Update () {
        if (shrink)
        {
            transform.localScale -= PerTime;
            Des();
        }
	}

    void Des()
    {
        if(transform.localScale.x <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    public void smallLet()
    {
        PerTime = transform.localScale / parcent;
        shrink = true;
        gameObject.layer = 8;
        Invoke("reLayer", 0.5f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Crow")
        {
            Destroy(collision.gameObject);
            AudioSource click = GetComponent<AudioSource>();
            click.Play();
        }
    }
}
