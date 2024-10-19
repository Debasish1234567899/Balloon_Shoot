using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    public float speed = 10f;

    bool ismoving;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (ismoving)
        {
            Invoke("CubeMove", 3);
        }
    }
    public void OnClickMove()
    {
       ismoving = true;
        
    }

    void CubeMove()
    {
        this.transform.position += Vector3.forward * speed* Time.deltaTime;
    }
}
