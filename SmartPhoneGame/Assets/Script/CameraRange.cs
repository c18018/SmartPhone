using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRange : MonoBehaviour {

    public float minPosX;
    public float maxPosX;
    public float minPosY;
    public float maxPosY;
    public GameObject player;

    private Vector3 offset;
    private float cameraX;
    private float cameraY;

    void Start () {
        offset = transform.position - player.transform.position;
	}
	
	void Update () {
        CameraMove();
	}

    void CameraMove()
    {
        cameraX = Mathf.Clamp(player.transform.position.x + offset.x, minPosX, maxPosX);
        cameraY = Mathf.Clamp(player.transform.position.y + offset.y, minPosY, maxPosY);
        transform.position = new Vector3(cameraX, cameraY, transform.position.z);
    }
}
