using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleted : MonoBehaviour
{
    LevelManager levelManager;

    private void Start()
    {
        LevelManager.Instance.LevelCompleted += OnCompleted;
    }

    void OnCompleted()
    {
        this.gameObject.SetActive(true);
        Debug.Log("LevelCompletedtext");
    }
}
