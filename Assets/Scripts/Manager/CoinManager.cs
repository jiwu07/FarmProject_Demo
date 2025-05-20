using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
    
    private int initialCoins = 15;
    private int currentCoins;
    
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
        currentCoins = initialCoins;
       
    }

    public int GetInitailCoins()
    {
        return initialCoins;
    }

    public int GetCurrentCoins()
    {
        return currentCoins;
    }

    public void AddCoin(int amount)
    {
        currentCoins += amount;
        CoinUI.Instance.ShowCoinChange(amount);
    }

    public void SubtractCoin(int amount)
    {
        if (currentCoins < amount) return;
        currentCoins -= amount;
        CoinUI.Instance.ShowCoinChange(-amount);
    }
}
