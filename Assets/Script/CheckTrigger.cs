using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        //coin ?
        if(other.gameObject.tag == "Coin")  
        {
            //Add score ++
            FindObjectOfType<AudioManager>().Play("Coin");
            GameManager.Instance.AddScore();
            Destroy(other.gameObject, 0.02f); 
        }

        //wall
        if(other.gameObject.tag == "Wall")
        {
             FindObjectOfType<AudioManager>().Play("GameOver");
            GameManager.Instance.GameOver();
        }
    }
}
