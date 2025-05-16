using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterDetailUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image icon;
    
    private CharacterSO characterSO;

   

    public void IniteDetail(CharacterSO CharacterSO)
    {
        /*if(characterSO == null) { Debug.Log("empty so ");return; }
        Debug.Log(CharacterSO.characterName);*/
        nameText.text = CharacterSO.characterName;
        descriptionText.text = CharacterSO.description;
        icon.sprite = CharacterSO.icon;
        characterSO = CharacterSO;

    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
    public void SwitchCharacter()
    {
        CharacterManager.instance.SwitchCharacter(characterSO);
    }
}
