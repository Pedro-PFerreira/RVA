using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonLogic : MonoBehaviour
{
    public GameObject PauseButtonUI;
    public PauseMenuLogic PauseMenuUI;
    private void Start(){
        PauseButtonUI.SetActive(true);
    }

    public void PauseGame(){
        PauseMenuUI.PauseGame();
        Time.timeScale = 0f;
        PauseButtonUI.SetActive(false);
    }

    public void ResumeGame(){
        Time.timeScale = 0f;
        PauseButtonUI.SetActive(true);
    }
}
