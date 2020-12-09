using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBloemen : MonoBehaviour
{
    public bool bloem1 = true;
    public bool bloem2 = true;
    public bool bloem0 = true;
    public float waitTime = 3.0f;

    public GameObject SpawnPosition0;
    public GameObject SpawnPosition1;
    public GameObject SpawnPosition2;
    public GameObject ObjectToCreate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bloem0 == false)
        {
            StartCoroutine(SpawnObject0());

        } else if (bloem1 == false)
        {
            StartCoroutine(SpawnObject1());
        }
        else if (bloem2 == false)
        {
            StartCoroutine(SpawnObject2());
        }
    }

    IEnumerator SpawnObject0()
    {
        bloem0 = true;
        yield return new WaitForSeconds(waitTime);
        Instantiate(ObjectToCreate, SpawnPosition0.transform.position, Quaternion.identity);
    }

    IEnumerator SpawnObject1()
    {
        bloem1 = true;
        yield return new WaitForSeconds(waitTime);
        Instantiate(ObjectToCreate, SpawnPosition1.transform.position, Quaternion.identity);
    }

    IEnumerator SpawnObject2()
    {
        bloem2 = true;
        yield return new WaitForSeconds(waitTime);
        Instantiate(ObjectToCreate, SpawnPosition2.transform.position, Quaternion.identity);
    }

}