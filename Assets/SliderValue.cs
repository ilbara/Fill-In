using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    [SerializeField] Slider slider;
      
    
    private void Update()
    {
        slider.value = LevelManager.Instance.levelProgress;
    }
}
