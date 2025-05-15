using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    public static CharacterUI Instance; 
    public GameObject characterDetailUI;
    public GameObject characterList;

    public GameObject content;
    public GameObject itemPreFab;

    private bool isShow = false;
    

    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
       
    }

    
    /*public void AddCharacter(ItemSO itemSO)
    {
        GameObject item = Instantiate(itemPreFab);
        item.transform.parent = content.transform;
        
        item.GetComponent<ItemUI>().IniteItemUI(itemSO);

    }

    */
    public void ShowCharacterDetails(CharacterSO itemSO)
    {
        CharacterDetailUI.Instance.IniteDetail(itemSO);
        CharacterDetailUI.Instance.Show();
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
        List<CharacterSO> characters = CharacterManager.instance.characters;
        foreach (var character in characters)
        {
            GameObject go = Instantiate(itemPreFab, content.transform);
            go.transform.SetParent(content.transform);
            go.GetComponent<CharacterItemUI>().IniteItemUI(character);
        }

    }
}