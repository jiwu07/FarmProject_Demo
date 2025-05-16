using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    public static CharacterUI Instance;
    [SerializeField] private CharacterDetailUI characterDetailUI;
    [SerializeField] private GameObject characterList;

    [SerializeField] private GameObject content;
    [SerializeField] private GameObject itemPreFab;

    private bool isShow = false;
    

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
       
    }

   
    public void ShowCharacterDetails(CharacterSO itemSO)
    {
        characterDetailUI.Show();
        characterDetailUI.IniteDetail(itemSO);
        
    }

    
    /// <summary>
    /// Click on the button to show/Hide the character list
    /// </summary>
    public void MenuButtonOnClick()
    {
        if (isShow)
        {
            Debug.Log("Character UI is shown");
            characterList.gameObject.SetActive(false);
            characterDetailUI.Hide();
            isShow = false;
            return;
        }
        characterList.gameObject.SetActive(true);
        isShow = true;
    }

    
    /// <summary>
    /// go through all the exist character and update the character list/inventory
    /// </summary>
    public void UpdateCharacterList()
    {
        //remove all old item
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
        
        //create new item
        List<CharacterSO> characters = CharacterManager.instance.GetCharacters();
        foreach (var character in characters)
        {
            GameObject go = Instantiate(itemPreFab, content.transform);
            go.transform.SetParent(content.transform);
            go.GetComponent<CharacterItemUI>().IniteItemUI(character);
        }

    }
}