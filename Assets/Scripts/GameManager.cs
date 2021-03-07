using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

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
    }

    //private void Start()
    //{
    //    if (LevelManager.Instance.HandleCreateNextLevel())
    //    {
    //        Debug.Log("Go to next level!");

    //    }
    //    else
    //    {
    //        Debug.Log("No more Levelé");

    //    }

    //    LevelManager.Instance.LevelCompleted += OnLevelCompleted;
    //}

    void OnLevelCompleted()
    {
        Debug.Log("level completed");
        //LevelManager.Instance.CreateNextLevel();
    }
}
