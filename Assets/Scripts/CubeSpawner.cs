using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    //[SerializeField] Sprite sprite;

    //[SerializeField] Transform cubeSpawner;

    //[SerializeField] GameObject cubeObject;

    //[SerializeField] private float size = 1f;

    private Texture2D spriteTexture;

    Vector3 cubePos = Vector3.zero;

    Vector3 fillerPos = Vector3.zero;

    public List<GameObject> cubeCounter = new List<GameObject>();

   
    public List<GameObject> CreateCubesFromImage(LevelInfo levelInfo, Transform transform, Transform transform1)
    {
        List<GameObject> createdCubes = new List<GameObject>();
        spriteTexture = levelInfo.sprite.texture;

        for (int x=0; x < spriteTexture.width; x++)
        {
            for (int y = 0; y < spriteTexture.height; y++)
            {
                Color color = spriteTexture.GetPixel(x, y);

                if (color.a == 0)
                {
                    continue;
                }

                cubePos = new Vector3(
                    levelInfo.size * (x - (spriteTexture.width * .5f)),
                    -(levelInfo.size * .5f),
                    levelInfo.size * (y - (spriteTexture.height * .5f)));

                fillerPos = new Vector3(
                    levelInfo.size * (x - (spriteTexture.width * .5f)),
                    levelInfo.size * (y),
                    levelInfo.size * (y * .5f));


                GameObject baseObj = Instantiate(levelInfo.fillableObj, transform);
                baseObj.transform.localPosition = cubePos;

                GameObject fillerBaseObj = Instantiate(levelInfo.fillerObj, transform1);
                fillerBaseObj.transform.localPosition = fillerPos;
                fillerBaseObj.transform.localScale = Vector3.one * levelInfo.size;

                baseObj.GetComponent<Renderer>().material.color = color;
                baseObj.transform.localScale = Vector3.one * levelInfo.size;


                createdCubes.Add(baseObj);
                cubeCounter.Add(baseObj);

            }
            
        }
        
        return createdCubes;
    }
}
