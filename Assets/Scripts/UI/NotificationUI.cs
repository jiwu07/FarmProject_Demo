using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationUI : MonoBehaviour
{
    static public NotificationUI Instance;
    
    [SerializeField] private TextMeshProUGUI textUI;
    [SerializeField] private Image imageUI;
    private float floatUpSpeed = 0.8f;
    private float alpha = 0;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        } 
        
        Instance = this;
    }

    private void Update()
    {
        if (textUI.enabled)
        {
            Color textColor = textUI.color;
            Color imageColor = imageUI.color;

            alpha = Mathf.Lerp(textColor.a, 0, Time.deltaTime);

            textUI.color = new Color(textColor.r, textColor.g, textColor.b, alpha);
            imageUI.color = new Color(imageColor.r, imageColor.g, imageColor.b, alpha/2);

            if (alpha <= 0.01f)
            {
                textUI.enabled = false;
                imageUI.enabled = false;
            }
        }
    }

    public void Show(string message)
    {
        textUI.enabled = true;
        imageUI.enabled = true;

        textUI.text = message;

        textUI.color = new Color(0, 0, 0, 1f);      
        imageUI.color = new Color(1, 1, 1, 0.5f);     
    }

}
