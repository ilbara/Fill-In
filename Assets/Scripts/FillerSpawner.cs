using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillerSpawner : MonoBehaviour
{
    CubeSpawner cubeSpawner;

    [SerializeField] GameObject fillerPrefab;
    [SerializeField] Transform fillerSpawnPoint;

    private void Awake()
    {
        cubeSpawner = GetComponent<CubeSpawner>();        
    }

    void SpawnFillers()
    {
        for (int i = 0; i < 50; i++)
        {
            Instantiate(fillerPrefab,fillerSpawnPoint);
        }
    }

    private void Start()
    {
        SpawnFillers();
        Debug.Log("hebeb" + cubeSpawner.cubeCounter.Count);
    }
}
