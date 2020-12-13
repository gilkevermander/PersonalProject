using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GifRegenManager : MonoBehaviour
{

    public bool danger = false;
    public GameObject[] GifPrefabs;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void invoke()
    {
        int startDelay = 0;
        int spawnInterval = 1;
        Debug.Log("invoke");
        InvokeRepeating("SpawnRandomGif", startDelay, spawnInterval);
    }

    public void cancel()
    {
        CancelInvoke();
    }

    //public IEnumerator startGame()
    //{
    //    int startDelay = 0;
    //    yield return new WaitForSeconds(1.0f);//40
    //    danger = true;
    //    yield return new WaitForSeconds(0f);
    //    //InvokeRepeating("SpawnRandomGif", startDelay, 1f);//true zijn
    //    yield return new WaitForSeconds(4.0f);
    //    danger = false;
    //    yield return new WaitForSeconds(10.0f);//2
    //    CancelInvoke();//false zijn
    //}

    void SpawnRandomGif()
    {
        int gifIndex = Random.Range(0, GifPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-2.6f, -6f), 15f, 31.353f);

        Instantiate(GifPrefabs[gifIndex], spawnPos, GifPrefabs[gifIndex].transform.rotation);
    }
}
