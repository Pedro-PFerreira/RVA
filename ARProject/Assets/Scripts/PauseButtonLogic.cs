using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonLogic : MonoBehaviour
{
    public GameObject PauseButtonUI;
    public PauseMenuLogic PauseMenuUI;
    public void PauseGame(){
        Debug.Log("Pausing the Game...");
        PauseMenuUI.PauseGame();
        Time.timeScale = 0f;
        PauseButtonUI.SetActive(false);
    }

    public void ResumeGame(){
        Debug.Log("Resuming the Game...");
        Time.timeScale = 0f;
        PauseButtonUI.SetActive(true);
    }
}
