using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndgameMenuLogic : MonoBehaviour
{
    public void PlayAgain(){
        Debug.Log("Restarting the game...");
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu(){
        Debug.Log("Restarting the game...");
        SceneManager.LoadScene("MainMenu");
    }
}
