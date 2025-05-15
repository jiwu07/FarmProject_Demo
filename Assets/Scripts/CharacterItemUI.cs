using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterItemUI : MonoBehaviour
{
    private CharacterSO characterSO;
    [SerializeField]private Image icon;

    public void IniteItemUI(CharacterSO itemSO)
    {
        this.characterSO = itemSO;
        this.icon.sprite = itemSO.icon;
    }

    public void ShowDetail()
    {
        //show character details todo
        CharacterUI.Instance.ShowCharacterDetails(characterSO);
        
    }
}