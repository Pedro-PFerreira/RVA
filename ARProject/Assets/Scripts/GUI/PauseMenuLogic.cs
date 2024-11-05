using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuLogic : MonoBehaviour
{

    public GameObject PauseMenuUI;

    public PauseButtonLogic PauseButtonUI;

    private void Start(){
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ResumeGame(){
        PauseButtonUI.ResumeGame();
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
    }

    public void PauseGame(){
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BackToMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
