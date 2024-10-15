using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
