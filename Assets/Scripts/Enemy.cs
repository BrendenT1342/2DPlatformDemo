using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Waypoint1;
    public GameObject Waypoint2;
    public float speed;

    private Rigidbody2D rb;
    private Transform currentPoint;


    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       currentPoint = Waypoint2.transform;
    }

    void Update()
    {
        // These will make the enemy move left to right on the platform.
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == Waypoint2.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2 (-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == Waypoint2.transform)
        {
            currentPoint = Waypoint1.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == Waypoint1.transform)
        {
            currentPoint = Waypoint2.transform;
        }
    }



}
