using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public int number = 5;

    public GameObject boid;

	void Start () {
        Vector2 min = new Vector2(transform.position.x - 3.0f,
            transform.position.y + -3.0f);
        Vector2 max = new Vector2(transform.position.x + 3.0f,
            transform.position.y + 3.0f);
        for(int i = 0; i < number; i++)
        {
            Vector3 position = new Vector3(Random.Range(min.x, max.x),
                Random.Range(min.y, max.y), 0);
            float angle = Random.Range(0, 360.0f);

            GameObject boids = (GameObject)Instantiate(boid, position, Quaternion.AngleAxis(angle, Vector3.up));
            boids.transform.parent = transform;
        }
	}
}
