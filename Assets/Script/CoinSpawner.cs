using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public float maxTime;
   private float time;

   public float maxHeight;
   public float minHeight;

   public GameObject coinPrefab;
   GameObject coin;


    private void Start()
    {
        time = 1;

    }
   private void Update()
   {
     if(time > maxTime)
     {
        coin = Instantiate(coinPrefab);
        coin.transform.position = transform.position + new Vector3(0 ,Random.Range(minHeight ,maxHeight), 0);
        time = 0;
     }

     time += Time.deltaTime;
     Destroy(coin ,8f );
   }
}
