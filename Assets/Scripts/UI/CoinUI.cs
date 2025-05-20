using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    static public CoinUI Instance;
    
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI coinChangingText;
    
    private Color textColor;
    private float floatUpSpeed = 1f;
    private float alpha = 0;
    private Color redColor = Color.red;
    private Color greenColor = Color.green;

    void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        } 
        
        Instance = this;
        
        coinText.text = CoinManager.Instance.GetInitailCoins().ToString();
        textColor = coinChangingText.color;
        coinChangingText.color = new Color(textColor.r, textColor.g, textColor.b, 0f);

    }
    
    public void ShowCoinChange(int amount)
    {
        if (amount < 0)
        {
            coinChangingText.text = amount.ToString();
            textColor = redColor;
        }
        else
        {
            coinChangingText.text ="+" + amount.ToString();
            textColor = greenColor;
        }
        coinChangingText.color = new Color(textColor.r, textColor.g, textColor.b, 1f);
        alpha = 1f;
        UpdateCoinUI();
    }

    void Update()
    {
        if (alpha > 0f)
        {
            alpha -= floatUpSpeed*Time.deltaTime;
        }
        else
        {
            alpha = 0f;
        }
        coinChangingText.color = new Color(textColor.r, textColor.g, textColor.b, alpha);
        
    }

    private void UpdateCoinUI()
    {
        coinText.text = CoinManager.Instance.GetCurrentCoins().ToString();
    }
    
   
}
