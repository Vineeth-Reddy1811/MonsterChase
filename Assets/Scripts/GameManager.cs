using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Used to select between 2 players
public class GameManager : MonoBehaviour
{


    public static GameManager instance;     //Only GM class has access to instance which can have access to all public elements in the class.

    private int _charIndex;

    [SerializeField]
    private GameObject[] characters;

    public int CharIndex {

        get{return _charIndex;}
        set{_charIndex = value;}
    }

    private void Awake(){                       //A SINGLETON PATTERN will allow you to have only one instance of game object and destroy others.
        if(instance ==null){                    //Its to avoid clashes and confusion.    
            instance = this;
            DontDestroyOnLoad(gameObject);      //It will not destroy the game manager
        }
        else {
            Destroy(gameObject);                //We destroy the duplicate.
        }

    }

    private void OnEnable(){
        SceneManager.sceneLoaded += OnLevelFinishedLoading;     //As soon as a new scene is loaded OnLevelFinishiedLoading wil be called.
        // += means we(listener) subscribe to the delgate... that is OnLevelFinishiedLoading function is listening to sceneLoaded.
    }

    private void OnDisable(){

        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        // -= means we(listener) unsubscribe to the delgate
    }
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)    //The structure of function should be similar to the structure of the delgate its listening to.
    {
            if(scene.name == "Gameplay"){
                Instantiate(characters[CharIndex]);
            }
    }
}
