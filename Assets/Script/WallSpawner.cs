using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
   public float maxTime;
   private float time;

   public float maxHeight;
   public float minHeight;

   public GameObject wallPrefab;
   GameObject wall;


    private void Start()
    {
        time = 1;

    }
   private void Update()
   {
     if(time > maxTime)
     {
        wall = Instantiate(wallPrefab);
        wall.transform.position = transform.position + new Vector3(0 ,Random.Range(minHeight ,maxHeight), 0);
        time = 0;
     }

     time += Time.deltaTime;
     Destroy(wall ,8f );
   }
}
