using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] [Range(1, 30)] float time;
    [SerializeField] GameObject enemy;
    [SerializeField] int poolSize = 5;
    GameObject[] pool;
    
    void Awake() 
    {
        Pool();
    }

    void OnEnable()
    {
        StartCoroutine(spawnEnemy());
    }

    void Pool()
    {
        pool = new GameObject[Mathf.Abs(poolSize)];

        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate (enemy, transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObject()
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
            pool[i].SetActive(true);
            return;
            }
        }
    }


    IEnumerator spawnEnemy()
    {
        while(true)
        {
        EnableObject();
        yield return new WaitForSeconds(time);
        }
    }
}
