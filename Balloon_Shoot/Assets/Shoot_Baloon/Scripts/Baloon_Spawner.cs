using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon_Spawner : MonoBehaviour
{
    Vector2 SpawnPoint;
    float currentTime ;
    float Duration = 4f;

    

    void Start()
    {
       

    }
    
   

    
    void Update()
    {
        

        if (Time.time - currentTime >= Duration)
        {
            Duration -= 0.1f;
            
            _SpawnBalloon();
            currentTime = Time.time;
        }
    }
    

    void _SpawnBalloon()
    {
        float positionX = Random.Range(-5, 5);
        SpawnPoint = new Vector2 (positionX, -9.75f);

        GameObject spawnedObject = ObjectPool.instance.GetPoolGameObject();
        if(spawnedObject != null )
        {
            spawnedObject.transform.position = SpawnPoint;
            spawnedObject.SetActive(true);
        }
        
    }
}

