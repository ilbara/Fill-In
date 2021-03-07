using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillerCube : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Filler"))
        {

            transform.Translate(Vector3.up * 0.22f);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            Debug.Log("Risin' Up!");

            var cubeController = GetComponent<CubeController>();

            if(cubeController)
            {
                cubeController.CubeState = CubeState.Filled;
            }

            Destroy(other.gameObject);
        }
       
    }
}
