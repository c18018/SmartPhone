using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{

    public float speed;
    public float sight;
    public float alignment;
    public float cohesion;
    public float separation;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

    void Update()
    {
        var neighbors = GetNeighbors();

        if (neighbors.Count == 0) return;

        var direction = cohesion * GetCohesion(neighbors)
          + alignment * GetAlignment(neighbors)
         + separation * GetSeparation(neighbors);

        GetComponent<Rigidbody2D>().velocity =
           (GetComponent<Rigidbody2D>().velocity.normalized + direction) * speed;

        transform.up = GetComponent<Rigidbody2D>().velocity.normalized;
    }

    List<Transform> GetNeighbors()
    {
        var index = transform.GetSiblingIndex();

        List<Transform> neighbors = new List<Transform>();

        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (i != index)
            {
                Transform child = transform.parent.GetChild(i);
                if (Vector2.Distance(child.position, transform.position) < sight)
                {
                    neighbors.Add(child);
                }
            }
        }

        return neighbors;
    }


    Vector2 GetAlignment(List<Transform> neighbors)
    {
        Vector3 alignment = new Vector3(0, 0, 0);

        foreach (var boid in neighbors)
        {
            alignment += boid.up;
        }

        return alignment.normalized;

    }


    Vector2 GetCohesion(List<Transform> neighbors)
    {
        var centerOfMass = new Vector3(0, 0, 0);

        foreach (var boid in neighbors)
        {
            centerOfMass += boid.position;
        }

        return (centerOfMass / neighbors.Count - transform.position).normalized;

    }


    Vector2 GetSeparation(List<Transform> neighbors)
    {
        var distance = new Vector3(0, 0, 0);

        foreach (var boid in neighbors)
        {
            distance += (boid.position - transform.position);
        }

        return (distance / neighbors.Count * -1).normalized;

    }
}
