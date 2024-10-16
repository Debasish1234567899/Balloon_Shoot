using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    
    //GameOver
    [SerializeField]GameObject GameOver_Panel;
    [SerializeField]Canvas canvas;
    [SerializeField]GameObject Pause_Panel;
    [SerializeField] GameObject SetParent;
    [SerializeField] Text GameOVerHighScore;
    GameObject SpawnManager;
    GameObject Balloon;
    bool isGameOver;

    void GameOver()
    {
        
        SpawnManager.GetComponent<Baloon_Spawner>().enabled = false;
        GameObject Go = Instantiate(GameOver_Panel, canvas.transform);
        Go.transform.SetParent(canvas.transform);
        RectTransform rectTransform = Go.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = Vector2.zero;
        rectTransform.localScale = Vector3.one;
        SetParent.SetActive(false);
        GameOVerHighScore.text = "Your Score is : " + BalloonMovement.ScoreNumbers;

        isGameOver = true;


    }
    void Start()
    {
        
        SpawnManager = GameObject.Find("Baloon_Spawner");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(BalloonMovement.HealthNumber == 0 && !isGameOver )
        {
            
           
                for (int i = 0; i < 1; i++)
                {

                    GameOver();
                    isGameOver = true;
                }
           
            
            
        }
    }
    public void RestartLevel()
    {
        GameObject Go = GameObject.Find("GameOver_Panel(Clone)");
        if ( Go != null )
        {
            Destroy(Go);
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        }
        else
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        }
       
        
       
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
