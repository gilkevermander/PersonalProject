using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSneukies : MonoBehaviour
{
    public GameObject[] SneukiePrefabs;
    private int spawnRangeX = 10;
    private int spawnRangeZ = 20;
    public float startDelay = 0;
    public float startInterval = 0.4f;
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
        int sneukieIndex = Random.Range(0, SneukiePrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-2.6f, -6f), 15f, 31.02f);

        Instantiate(SneukiePrefabs[sneukieIndex], spawnPos, SneukiePrefabs[sneukieIndex].transform.rotation);
    }
}
