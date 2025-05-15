using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterDetailUI : MonoBehaviour
{
    public static CharacterDetailUI Instance; 
    void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
       
    }

    public void IniteDetail(CharacterSO CharacterSO)
    {
        //todo
        Debug.Log(CharacterSO.name);
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    
    private void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
