using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuLogic : MonoBehaviour
{
    //private bool GameIsPaused = true;

    public GameObject PauseMenuUI;

    public PauseButtonLogic PauseButtonUI;

    private void Start(){
        PauseMenuUI.SetActive(false);
    }

    public void ResumeGame(){
        Debug.Log("Resuming Game...");
        PauseButtonUI.ResumeGame();
        Time.timeScale = 1f;
        //GameIsPaused = false;
        PauseMenuUI.SetActive(false);
    }

    public void OpenSettings(){
        Debug.Log("Opening Settings...");
    }

    public void PauseGame(){
        Debug.Log("Pausing the Game...");
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        //GameIsPaused = true;
    }

    public void BackToMenu(){
        Debug.Log("Going Back to Main Menu...");
        SceneManager.LoadScene("MainMenu");
    }
}
