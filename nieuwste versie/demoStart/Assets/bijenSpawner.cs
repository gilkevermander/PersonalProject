using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bijenSpawner : MonoBehaviour
{
    public GameObject[] bijtjes;
    public GameObject bij0;
    public GameObject bij1;
    public GameObject bij2;
    public GameObject bij3;
    public GameObject bij4;
    public GameObject bij5;

    public GameObject bij0pos;
    public GameObject bij1pos;
    public GameObject bij2pos;
    public GameObject bij3pos;
    public GameObject bij4pos;
    public GameObject bij5pos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bijen());


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator bijen()
    {
        Instantiate(bij0, bij0pos.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Instantiate(bij1, bij1pos.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(bij2, bij2pos.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(bij3, bij3pos.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(bij4, bij4pos.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bij5, bij5pos.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
    }
}
