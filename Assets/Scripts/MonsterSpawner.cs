using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] monsterReference;
    [SerializeField]
    private Transform leftPos, rightPos;
    private GameObject spawnedMonster;

    private int randomIndex;
    private int randomSide;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    //We create a co-routine
    IEnumerator SpawnMonsters(){
        while(true){
            yield return new WaitForSeconds(Random.Range(1,5));     //Because we have this wait time, our while loop will be in control.

            randomIndex = Random.Range(0, monsterReference.Length); // it will give a random number between 0 and the length of array MonsterRefernce(that is 0-2 cuz we have 3 monsters.)

            randomSide = Random.Range(0,2);

            spawnedMonster =Instantiate(monsterReference[randomIndex]); //Instantiate means it creates a copy of the monster.

            if(randomSide == 0){
                //left side
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4,10); //instead of specifying speed in Monster.cs we give it a random value here.
            }
            else{
                //right side
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4,10);       //We give a '-' cuz its reverse direction.
                spawnedMonster.transform.localScale = new Vector3(-1f,1f,1f);        //This is to flip the monster.
        }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
