using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUI : MonoBehaviour{

    public enum MenuType{
        DifficultyMenu,
        GameOverMenu,

        HowToPlayMenu,
        MainMenu,
        PauseButton,
        PauseMenu,
        VictoryMenu
    }

    [SerializeField] MenuType MenuIdentifier;

    void Start(){
        if (MenuIdentifier == MenuType.MainMenu){
            PlayerPrefs.SetString("Difficulty","Easy");
        }
    }
    public void StartGame(string difficulty){
        Debug.Log("Starting a " + difficulty + " match...");
        PlayerPrefs.SetString("Difficulty",difficulty);
        PlayerPrefs.Save();
        SceneManager.LoadScene("GameScene");
    }

    public void HowToPlay(){
        Debug.Log("How to Play Opening...");
    }

    public void QuitGame(){
        Debug.Log("Leaving the game...");
        Application.Quit();
    }

    public void PlayAgain(){
        Debug.Log("Restarting the game...");
        SceneManager.LoadScene("DifficultyMenu");
    }

    public void GoToMenu(string menu){
        SceneManager.LoadScene(menu);
    }
}
