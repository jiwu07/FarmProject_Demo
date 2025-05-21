using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;
    [SerializeField] private List<CharacterSO> characters;
    [SerializeField] private Transform player;
    private GameObject currentPlayer;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        InitialCharacter();
    }

    private void InitialCharacter()
    {
        if (characters.Count < 0 || player.childCount > 0) return;
        SwitchCharacter(characters[0]);
    }

    public List<CharacterSO> GetCharacters()
    {
        return characters;
    }
    public void SwitchCharacter(CharacterSO character)
    {
        if (currentPlayer != null) Destroy(currentPlayer);
        player.rotation = Quaternion.Euler(0,0, 0);
        GameObject go = Instantiate(character.prefab,player.position,Quaternion.identity);
        go.transform.SetParent(player.transform);
        currentPlayer = go;
        Player.Instance.CharacterSOSwitch(character);
        
    }
    
     
    /*public void AddCharacter(ItemSO itemSO)
    {
        GameObject item = Instantiate(itemPreFab);
        item.transform.parent = content.transform;

        item.GetComponent<ItemUI>().IniteItemUI(itemSO);

    }

    */
}
