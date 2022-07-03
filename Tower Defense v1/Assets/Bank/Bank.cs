using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingMoney = 150;
    int currentMoney;
    [SerializeField] TMP_Text moneyText;
    [SerializeField] GameObject youwin;
    public int CurrentMoney {get {return currentMoney;}}
    
    void Awake() 
    {
        currentMoney = startingMoney;
        youwin.SetActive(false);
    }
    public void Deposit(int amount)
    {
        currentMoney += Mathf.Abs(amount); //mutlak değer
    }

    public void Withdraw(int nAmount)
    {
        if(currentMoney > 0) 
        currentMoney -= Mathf.Abs(nAmount);

        if(currentMoney <= 0)
        currentMoney = 0;
    }

    void Update() 
    {
        moneyText.text = "Sikke : " + currentMoney.ToString();

        if(currentMoney >= 600)
        {
            youwin.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
