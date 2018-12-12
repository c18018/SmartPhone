using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class size : MonoBehaviour {
    
    
	void Start () {
        float width = GetComponent<SpriteRenderer>().bounds.size.x;
        float height = GetComponent<SpriteRenderer>().bounds.size.y;
        Debug.Log(width + " : " + height);
	}
	
	void Update () {
		
	}
}
