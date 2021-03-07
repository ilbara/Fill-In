using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Text LevelCompleteText;
    // Start is called before the first frame update
    void Start()
    {
        LevelManager.Instance.LevelCompleted += OnCompleted;
        LevelManager.Instance.NextLevelTrans += OnTrans;
    }

    void OnCompleted()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    void OnTrans()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
