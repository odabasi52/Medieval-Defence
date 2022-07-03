using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Enemy))]
public class enemyDying : MonoBehaviour
{
    Enemy enemy;
    int health;
    int maxHealth = 4;
    [SerializeField] Slider healthBar;
    [SerializeField] AudioClip hit;
    [SerializeField] GameObject boom;
    AudioSource ass;
    void Start() 
    {
        enemy = GetComponent<Enemy>();
        ass = GetComponent<AudioSource>();
    }
    void OnEnable() 
    {
       healthBar.value = maxHealth;
       healthBar.maxValue = maxHealth;

       health = maxHealth;
       healthBar.gameObject.SetActive(false);
    }
    void OnParticleCollision(GameObject other) 
    {
        health--;
        healthBar.gameObject.SetActive(true);
        healthBar.value = health;
        ass.PlayOneShot(hit);

        if(health <= 0 )
        {
            gameObject.SetActive(false);
            healthBar.gameObject.SetActive(false);

            
            Instantiate(boom , transform.position , Quaternion.identity);
            
            if(maxHealth < 40) {maxHealth = maxHealth + 2;}
            
            enemy.RewardGold();
        }
    }
}
