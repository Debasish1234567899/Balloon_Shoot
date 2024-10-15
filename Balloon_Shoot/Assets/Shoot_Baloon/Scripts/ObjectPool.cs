using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
   private List<GameObject> BaloonList = new List<GameObject>();
    int PoolAmount = 20;
    [SerializeField] GameObject[] Balloon;

    [SerializeField] Transform SteParent;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        for(int i = 0; i < PoolAmount; i++)
        {
            GameObject go = Instantiate(Balloon[i]);
            go.transform.SetParent(SteParent);
            BaloonList.Add(go);
            go.SetActive(false);
        }
    }

    public GameObject GetPoolGameObject()
    {
        for (int i = 0;i < BaloonList.Count; i++)
        {
            if (!BaloonList[i].activeInHierarchy)
            {
                return BaloonList[i];
            }
            
        }
        return null;
    }
}
