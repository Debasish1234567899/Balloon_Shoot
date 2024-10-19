using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    bool isGameOver = false;
    [SerializeField] GameObject GameOver_Panel;
    [SerializeField] Canvas canvas;
    [SerializeField] Text GameOVerHighScore;
    GameObject SpawnManager;
    [SerializeField] GameObject SetParent;

    void Start()
    {

        SpawnManager = GameObject.Find("Baloon_Spawner");
        SetParent.SetActive(true);
        BalloonMovement.HealthNumber = 3;


    }
    void GameIsOver()
    {

        SpawnManager.GetComponent<Baloon_Spawner>().enabled = false;
        GameObject Go = Instantiate(GameOver_Panel, canvas.transform);
        Go.transform.SetParent(canvas.transform);
        RectTransform rectTransform = Go.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = Vector2.zero;
        rectTransform.localScale = Vector3.one;
        SetParent.SetActive(false);
        
        GameOVerHighScore.text = "Your Score is : " + BalloonMovement.ScoreNumbers;
        GameOVerHighScore.text = "" + BalloonMovement.ScoreNumbers;
        


    }
    void Update()
    {
        if (BalloonMovement.HealthNumber == 0 && !isGameOver)
        {
            isGameOver = true;
            for (int i = 0; i < 1; i++)
            {
                GameIsOver();
                
            }

        }
    }
    public void Restatrt()
    {
       GameObject Go = GameObject.Find("GameOver_Panel(Clone)");
        Destroy(Go);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        SetParent.SetActive(true);
        BalloonMovement.HealthNumber = 3;
        BalloonMovement.ScoreNumbers = 0;
    }
}
