using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    //GameOver
    [SerializeField]GameObject GameOver_Panel;
    [SerializeField]GameObject Pause_Panel;
    [SerializeField] GameObject SetParent;
    [SerializeField] Text GameOVerHighScore;
    GameObject SpawnManager;
    GameObject Balloon;

    void GameOver()
    {
        
        SpawnManager.GetComponent<Baloon_Spawner>().enabled = false;
        Instantiate(GameOver_Panel, Vector2.zero, Quaternion.identity);
        SetParent.SetActive(false);
        GameOVerHighScore.text = "Your Score is : " + BalloonMovement.ScoreNumbers;
        
    }
    void Start()
    {
        
        SpawnManager = GameObject.Find("Baloon_Spawner");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(BalloonMovement.HealthNumber == 0)
        {
            for (int i = 0; i < 1; i++)
            {

                GameOver();
            }
            
            
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        Pause_Panel.SetActive(false);
       
    }
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
