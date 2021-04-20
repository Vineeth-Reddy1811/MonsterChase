using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) 
    
    {
        if(collision.CompareTag("Enemy")|| collision.CompareTag("Player")) {        //We compare with player and enemy types of tags
            Destroy(collision.gameObject);      //We destroy the game object that we collided with


        }
    }




}
