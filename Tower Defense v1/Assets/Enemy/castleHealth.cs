using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class castleHealth : MonoBehaviour
{   
    [SerializeField] int health = 6;
    [SerializeField] Slider heal;
    [SerializeField] GameObject youlost;
    [SerializeField] AudioClip over;

    void Start() 
    {
        heal.value = 6;
        heal.gameObject.SetActive(false);
        youlost.SetActive(false);
    }
    void OnTriggerEnter(Collider other) 
    {
        health--;

        heal.gameObject.SetActive(true);
        heal.value = health;

        if(health <= 0)
        {
            GetComponent<AudioSource>().PlayOneShot(over);
            Time.timeScale = 0;
            youlost.SetActive(true);
        }
    }
}
