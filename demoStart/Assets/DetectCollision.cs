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
        //Debug.Log(other.name);
        //parent = other.transform.parent.parent.parent.parent.parent.parent.parent.parent.gameObject;
        //Debug.Log(parent.name);
        if (other.name == "paraplu1" || other.name == "paraplu")
        {
            
        }
        if (other.name == "bloemSpawn 1(Clone)")
        {
            Debug.Log("code werkt half");
            parent.GetComponent<SneukieAnimatie>().dor = true;
        }
            
        StartCoroutine(Break());

    }

    private IEnumerator Break()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        sound.Play(0);
        particle.Play();
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}
