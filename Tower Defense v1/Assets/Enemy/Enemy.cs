using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   Bank bank;
   [SerializeField] int rewardMoney = 25;
   [SerializeField] int penaltyMoney = 25;


    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold() 
    {
        if(bank == null) {return;}
        bank.Deposit(rewardMoney);
    }

    public void PenaltyGold()
    {
        if(bank == null) {return;}
        bank.Withdraw(penaltyMoney);
    }

    
}
