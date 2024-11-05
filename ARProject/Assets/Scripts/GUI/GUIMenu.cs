using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIMenu : MonoBehaviour{

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
        PlayerPrefs.SetString("Difficulty",difficulty);
        PlayerPrefs.Save();
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void PlayAgain(){
        SceneManager.LoadScene("DifficultyMenu");
    }

    public void GoToMenu(string menu){
        SceneManager.LoadScene(menu);
    }
}
