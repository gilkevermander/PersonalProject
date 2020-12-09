using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerBee : MonoBehaviour
{
    public GameObject[] BeePrefabs;
    private int spawnRangeX = 10;
    private int spawnRangeZ = 20;
    public float startDelay = 2;
    public float startInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBee", startDelay, startInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomBee()
    {
        int beeIndex = Random.Range(0, BeePrefabs.Length);
        Vector3 spawnPos = new Vector3(-5.8f, 13.9f, 28.7f);

        Instantiate(BeePrefabs[beeIndex], spawnPos, BeePrefabs[beeIndex].transform.rotation);
    }
}
