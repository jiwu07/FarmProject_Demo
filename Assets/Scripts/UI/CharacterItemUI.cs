using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterItemUI : MonoBehaviour
{
    [SerializeField]private Image icon;
    private CharacterSO characterSO;
    public void IniteItemUI(CharacterSO itemSO)
    {
        this.characterSO = itemSO;
        this.icon.sprite = itemSO.icon;
    }

    public void ShowDetail()
    {
        //show character details 
        CharacterUI.Instance.ShowCharacterDetails(characterSO);
        Debug.Log("characterSO");
    }
}