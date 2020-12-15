using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerGif : MonoBehaviour
{
    public GameObject[] GifPrefabs;
    private int spawnRangeX = 10;
    private int spawnRangeZ = 20;
    public float startDelay = 0;
    public float startInterval = 1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomGif", startDelay, startInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomGif()
    {
        int gifIndex = Random.Range(0, GifPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-2.6f, -6f), 15f, 31.353f);

        Instantiate(GifPrefabs[gifIndex], spawnPos, GifPrefabs[gifIndex].transform.rotation);
    }
}
