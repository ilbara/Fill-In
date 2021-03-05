using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance => instance;

    public Action LevelCompleted;

    [SerializeField] LevelInfoAsset levelInfoAsset;

    [SerializeField] private Transform cubeSpawnerPoint;

    [SerializeField] private Transform fillerSpawnerPoint;

    private static LevelManager instance;

    int currentLevelIndex = 0;

    int totalCubes;

    CubeSpawner cubeSpawner = new CubeSpawner();

    

    List<CubeController> createdCubes = new List<CubeController>();
    List<CubeController> collectedCubes = new List<CubeController>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

       
        cubeSpawner = GetComponent<CubeSpawner>();
    }

    public bool HandleCreateNextLevel()
    {
        if (createdCubes.Count > 0)
        {
            for (int i = 0; i < createdCubes.Count; i++)
            {
                Destroy(createdCubes[i]);
            }
        }

        ++currentLevelIndex;

        if (levelInfoAsset.levelInfos.Count >= currentLevelIndex)
        {
            CreateNextLevel();
            return true;
        }

        return false;
    }

    void CreateNextLevel()
    {
        cubeSpawner.CreateCubesFromImage(levelInfoAsset.levelInfos[currentLevelIndex - 1], cubeSpawnerPoint, fillerSpawnerPoint);

    }

    public void OnCubeCreated(CubeController cubeController)
    {
        createdCubes.Add(cubeController);
        Debug.Log("Collected Block Count" + collectedCubes.Count);
    }

    public void OnCubeCollected(CubeController cubeController)
    {
        collectedCubes.Add(cubeController);
        Debug.Log($"{ collectedCubes.Count} / { createdCubes.Count} <- collectedCubes Block Count");       

        if (collectedCubes.Count == createdCubes.Count)
        {
            LevelCompleted?.Invoke();
        }
    }
    public void CubeCounter()
    {
        totalCubes++;
    }


    

}

