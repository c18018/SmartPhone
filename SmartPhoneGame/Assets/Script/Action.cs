using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour {

    Vector3 screenPos;
    Vector3 swellPos;
    Vector3 startPos;

    public GameObject Maru;
    public GameObject balloon;
    GameObject maruObj;

    float scaleXZ;
    float scaleY;
    public float time;
    public float ratio;
    public float maxScale;
    float distance;
    float balloonY;
    float balloonCenterY;
    public float shotSpeed;

    public float radius;

    float Height;
    float Width;

    bool swell;

    private void Start()
    {
        Width = Screen.width;
        Height = Screen.height;
        swell = true;
    }

    void Update ()
    {
        screenPos = Input.mousePosition;
        screenPos.z = 10.0f;

        if (Input.GetButtonDown("Fire1")) Swell();
        if (Input.GetButton("Fire1")) Extend();
        if (Input.GetButtonUp("Fire1")) Break();

    }

    void Swell()
    {
        if (swell)
        {
            startPos = screenPos;
            swellPos = Camera.main.ScreenToWorldPoint(screenPos);
            swellPos.z = 300f;

            balloon.transform.position = swellPos;
            balloon.transform.rotation = Quaternion.Euler(0, 0, 0);

            maruObj = (GameObject)Instantiate(Maru, swellPos, Quaternion.identity);
            maruObj.transform.localScale = new Vector3(0, 0, 1);
            maruObj.transform.parent = balloon.transform;

            AudioSource click = GetComponent<AudioSource>();
            click.Play();
        }

    }

    void Extend()
    {
        distance = (screenPos - startPos).magnitude;

        scaleXZ = scaleXZ + Time.deltaTime * time;
            scaleXZ = Mathf.Clamp(scaleXZ, 0f, maxScale);

        if (distance == 0)
        {
            scaleY = scaleY + Time.deltaTime * time;
            scaleY = Mathf.Clamp(scaleY, 0f, maxScale);
        }else{
            Vector3 direction = (screenPos - startPos).normalized;
            balloon.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

            balloonY = distance / (Width + Height) / 2 * ratio;
            balloonCenterY = radius * (scaleY + balloonY - 1);

            maruObj.transform.localPosition = new Vector3(0, balloonCenterY, 0);
        }

        maruObj.transform.localScale = new Vector3(scaleXZ, scaleY + balloonY, scaleXZ);
    }
    
    void Break()
    {
        scaleXZ = 0;
        scaleY = 0;
        balloonY = 0;
        maruObj.SendMessage("smallLet");
        Rigidbody2D balloonRig = maruObj.GetComponent<Rigidbody2D>();
        balloonRig.AddForce(maruObj.transform.up * shotSpeed * distance);

        swell = true;
    }
}
