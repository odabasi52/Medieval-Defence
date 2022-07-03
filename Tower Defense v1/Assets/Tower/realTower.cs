using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realTower : MonoBehaviour
{
    [SerializeField] int towerCost = 50;
  
    public bool CreateTower(Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null) {return false;}

        if(bank.CurrentMoney >= towerCost)
        {
        bank.Withdraw(towerCost);
        Instantiate (gameObject, position , Quaternion.identity);
        return true;
        }
        
        return false;
    }

}
