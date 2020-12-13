using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    AudioSource sound;
    private ParticleSystem particle;
    private GameObject parent;
    public float bottomBound = 12.7f;
    // Start is called before the first frame update

    void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collide");
        Debug.Log(other.name);
        
        //Debug.Log(other.name);
        //parent = other.transform.parent.parent.parent.parent.parent.parent.parent.parent.gameObject;
        //Debug.Log(parent.name);
        //Debug.Log(parent.name);
        if (other.name == "Cone_1" || other.name == "paraplu")
        {
            
        }
        if (other.name == "Plane" || other.name == "Plane_Instance" || other.name == "Plane_Instance_2" || other.name == "Plane_Instance_3" || other.name == "Plane_Instance_4" || other.name == "Plane_Instance_5" || other.name == "Plane_Instance_6")
        {
            Debug.Log("code werkt half");
            if(other.transform.parent.parent.parent.parent.parent.parent.parent.parent.gameObject != null)
            {
                other.transform.parent.parent.parent.parent.parent.parent.parent.parent.gameObject.GetComponent<SneukieAnimatie>().dor = true;
            } else
            {
                Debug.Log("tis null");
            }
        }
            
        StartCoroutine(Break());

    }

    private IEnumerator Break()
    {
        Debug.Log("ale werk hup");
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        sound.Play(0);
        particle.Play();
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}
