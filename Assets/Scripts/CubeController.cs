using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CubeState
{
    Default,
    Filled
}

public class CubeController : MonoBehaviour
{
    public CubeState CubeState
    {
        get
        {
            return cubeState;
        }

        set
        {
            cubeState = value;

            switch(cubeState)
            {
                case CubeState.Default:

                    OnCreated?.Invoke(this);

                    break;

                case CubeState.Filled:

                    OnFilled?.Invoke(this);

                    OnCreated -= LevelManager.Instance.OnCubeCreated;
                    OnFilled -= LevelManager.Instance.OnCubeCollected;

                    break;

                default:

                    break;
            }
        }
    }


    public System.Action<CubeController> OnCreated { get; set; }
    public System.Action<CubeController> OnFilled { get; set; }

    CubeState cubeState = CubeState.Default;

    private void Start()
    {
        CubeState = CubeState.Default;
    }

    private void OnEnable()
    {
        OnCreated += LevelManager.Instance.OnCubeCreated;
        OnFilled += LevelManager.Instance.OnCubeCollected;
    }
}
