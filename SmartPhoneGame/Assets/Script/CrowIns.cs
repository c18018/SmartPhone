using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowIns : MonoBehaviour {

    float time;
    public float timeOut;
    public int count;
    public GameObject crow;
    bool ins;

    void insTF()
    {
        ins = true;
    }

    void Update()
    {
        if (ins)
        {
            Appear();
        }
    }

    void Appear()
    {
        time += Time.deltaTime;
        Debug.Log(time);

        if (time >= timeOut)
        {
            time = 0.0f;

            Instantiate(crow, transform.position, Quaternion.identity);
            count--;
        }
        if(count < 1)
        {
            Destroy(gameObject);
        }
    }

    /*public GameObject[] crowKind;
    public int i;

    void Appear()
    {
        Instantiate(crowKind[i], transform.position, Quaternion.identity);
        Destroy(gameObject);
    }*/
}
