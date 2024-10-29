using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{

    public void StartGame(){
        Debug.Log("Starting the game...");
        SceneManager.LoadScene("DifficultyMenu");
    }

    public void HowToPlay(){
        Debug.Log("How to Play Opening...");
    }

    public void QuitGame(){
        Debug.Log("Leaving the game...");
        Application.Quit();
    }
}
