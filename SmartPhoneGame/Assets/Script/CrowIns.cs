using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowIns : MonoBehaviour {

    public GameObject[] crowKind;
    public int i;

    void Appear()
    {
        Instantiate(crowKind[i], transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
