using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBee : MonoBehaviour
{
    public float Speed = 1.0f;
    public Vector3 wayPoint;
    public float Range = 4.0f;

    void Start()
    {
        //initialise the target way point
        Wander();
    }

    void Update()
    {
        // this is called every frame
        // do move code here
        transform.position += transform.TransformDirection(Vector3.forward) * Speed * Time.deltaTime;
        if ((transform.position - wayPoint).magnitude < 1)
        {
            // when the distance between us and the target is less than 3
            // create a new way point target
            Wander();


        }
    }

    void Wander()
    {
        // does nothing except pick a new destination to go to

        wayPoint = new Vector3(Random.Range(transform.position.x - Range, transform.position.x + Range), 13.9f, Random.Range(transform.position.z - Range, transform.position.z + Range));
        wayPoint.y = 13.9f;
        // don't need to change direction every frame seeing as you walk in a straight line only
        transform.LookAt(wayPoint);
        //Debug.Log(wayPoint + " and " + (transform.position - wayPoint).magnitude);
    }
}
