using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{  
    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX,maxX;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;        //Gets the transform position of the item with "Player" tag
        //Debug.Log("The Selected Index is : " + GameManager.instance.CharIndex );  Checking singleton pattern
    }

    // Update is called once per frame
    void LateUpdate()       //Late Update is used instead of Update cuz LateUpdate is called after all the calculations in Update are fininshed.
    {

        if(!player)     //Condition to check if player is dead
            return;

        tempPos = transform.position;
        tempPos.x = player.position.x;

        if(tempPos.x <minX)
            tempPos.x = minX;
        if(tempPos.x>maxX)
            tempPos.x = maxX;


        transform.position = tempPos;
    }
}
