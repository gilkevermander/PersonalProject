using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardBee : MonoBehaviour
{

    public float speed = 0.5f;
    public GameObject target;
    public Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = GameObject.Find("finalbloem").transform.position;
        //Debug.Log(position);
    }

    // Update is called once per frame
    void Update()
    {

        
        //transform.Translate(Vector3.left * speed * Time.deltaTime);
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, position, step);
        //transform.position = Vector3.MoveTowards(target.transform.position.x, target.transform.position.y, target.transform.position.z) * speed * Time.deltaTime; ;
        //Debug.Log(target.transform.position);
    }
}
