using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //Used to switch to another scene


//Used to switch screens
public class MainMenuController : MonoBehaviour
{

    public void PlayGame(){
        //string clickedobj =UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;        //We import libraries
        //Debug.Log("Index: "+ clickedobj);
        //SceneManager.LoadScene("Gameplay");

        int selectedCharacter = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);     //TypeCasting

        GameManager.instance.CharIndex = selectedCharacter;      //instead of doing obj creation we use "static in GameManager Class 
        SceneManager.LoadScene("Gameplay");

    }




}
