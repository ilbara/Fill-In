using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance => instance;

    public Action LevelCompleted;

    public Action NextLevelTrans;

    [SerializeField] LevelInfoAsset levelInfoAsset;

    [SerializeField] private Transform cubeSpawnerPoint;

    [SerializeField] private Transform fillerSpawnerPoint;

    private static LevelManager instance;

    int currentLevelIndex = 1;   

    CubeSpawner cubeSpawner = new CubeSpawner();

    public float levelProgress;

    

    public List<CubeController> createdCubes = new List<CubeController>();
    public List<CubeController> filledCubes = new List<CubeController>();

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

    private void Start()
    {
        CreateNextLevel();
        LevelCompleted += HandleCreateNextLevel;
    }



    //public bool HandleCreateNextLevel()
    //{
    //    if (filledCubes.Count > 0)
    //    {
    //        for (int i = 0; i < filledCubes.Count; i++)
    //        {
    //            Destroy(filledCubes[i]);
    //        }
    //    }

    //    ++currentLevelIndex;

    //    if (levelInfoAsset.levelInfos.Count >= currentLevelIndex)
    //    {
    //        CreateNextLevel();
    //        return true;
    //    }

    //    return false;
    //}

    public void HandleCreateNextLevel()
    {
        if (filledCubes.Count > 0 )
        {
            for (int i = 0; i < filledCubes.Count; i++)
            {
                Destroy(filledCubes[i].gameObject);
                Destroy(filledCubes[i]);
            }
        }
        ++currentLevelIndex;
        if(levelInfoAsset.levelInfos.Count >= currentLevelIndex)
        {
            StartCoroutine(WaitforSeconds(2f));
           
            //StopAllCoroutines();
        }
    }

    IEnumerator WaitforSeconds(float time)
    {        
        yield return new WaitForSecondsRealtime(time);
        NextLevelTrans?.Invoke();
        CreateNextLevel();

    }




    public void CreateNextLevel()
    {
        cubeSpawner.CreateCubesFromImage(levelInfoAsset.levelInfos[currentLevelIndex - 1], cubeSpawnerPoint, fillerSpawnerPoint);

    }

    public void OnCubeCreated(CubeController cubeController)
    {
        createdCubes.Add(cubeController);
        Debug.Log("Collected Block Count" + filledCubes.Count);
    }

    public void OnCubeFilled(CubeController cubeController)
    {
        filledCubes.Add(cubeController);
        Debug.Log($"{ filledCubes.Count} / { createdCubes.Count} <- filledCubes Block Count");
        levelProgress = filledCubes.Count / createdCubes.Count;
        if (filledCubes.Count == createdCubes.Count)
        {
            LevelCompleted?.Invoke();
        }
    }

   




}

