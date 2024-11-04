using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenuLogic : MonoBehaviour
{

    public void StartGame(string difficulty){
        Debug.Log("Starting a " + difficulty + " match...");
        PlayerPrefs.SetString("Difficulty",difficulty);
        PlayerPrefs.Save();
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu(){
        Debug.Log("Restarting the game...");
        SceneManager.LoadScene("MainMenu");
    }
}