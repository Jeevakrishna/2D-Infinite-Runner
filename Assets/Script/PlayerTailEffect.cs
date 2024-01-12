using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTailEffect : MonoBehaviour
{
    public float startTimeBtwSpawn;
    float timeBtwSpawn;

    public GameObject tailPrefab;

    private void Update()
    {
        if(timeBtwSpawn <= 0)
        {
            GameObject tail = Instantiate(tailPrefab, transform.position , Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            Destroy(tail ,4f );
        }

        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
        
          
           
    }
}
