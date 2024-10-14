using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    //GameOver
    [SerializeField]GameObject GameOver_Panel;
    GameObject SpawnManager;
    void GameOver()
    {
        GameOver_Panel.SetActive(true);
        SpawnManager.GetComponent<Baloon_Spawner>().enabled = false;
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
}
