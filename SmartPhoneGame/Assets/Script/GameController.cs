using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Image Name;
    float alfa;
    public float speed;

    bool plus;

    float red, green, blue;

    void Start () {
        plus = true;
        red = Name.color.r;
        green = Name.color.g;
        blue = Name.color.b;
        alfa = 1;
	}
	
	void Update () {

        Name.color = new Color(red, green, blue, alfa);

        alfa -= speed;

        if (alfa < 0)
        {
            Destroy(Name);
            Destroy(GetComponent<GameController>());
            //.enabled = false;
        }
        Debug.Log(alfa);

        
	}
}
