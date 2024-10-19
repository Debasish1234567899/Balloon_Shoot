using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    
    
    
    
    [SerializeField]GameObject Pause_Panel;
    
    
    
    GameObject Balloon;
    

    
   

    
   
    
    public void HomeScreen()
    {
        SceneManager.LoadScene(0);
    }
    public void pauseGame()
    {
        Pause_Panel.SetActive(true);
        Time.timeScale = 0;
    } 
    public void ResumeGame()
    {
        Pause_Panel.SetActive(false);
        Time.timeScale = 1;
    }
     
}
