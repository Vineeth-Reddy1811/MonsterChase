using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Used for restart and Home button.
public class GamePlayUIController : MonoBehaviour
{
    // Start is called before the first frame update
    public void RestartGame(){
        //SceneManager.LoadScene("Gameplay"); OR
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);     //Returns the scene we are in
    }

    public void HomeButton(){
        SceneManager.LoadScene("MainMenu");  
    }
}
