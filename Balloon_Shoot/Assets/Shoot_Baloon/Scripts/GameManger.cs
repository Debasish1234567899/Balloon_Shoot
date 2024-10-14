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
    [SerializeField] Text GameOVerHighScore;
    GameObject SpawnManager;
    GameObject Balloon;
    void GameOver()
    {
        GameOver_Panel.SetActive(true);
        SpawnManager.GetComponent<Baloon_Spawner>().enabled = false;
        Balloon = GameObject.Find("Balloon 01(Clone)");
        if (Balloon != null )
        {
            Destroy( Balloon );
        }
        GameOVerHighScore.text = "Your Score is : " + BalloonMovement.ScoreNumbers;

    }
    void Start()
    {
        
        SpawnManager = GameObject.Find("Baloon_Spawner");

    }

    // Update is called once per frame
    void Update()
    {
        if(BalloonMovement.HealthNumber <= 0)
        {
            
            GameOver();
            
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
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
