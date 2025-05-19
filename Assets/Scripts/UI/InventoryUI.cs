using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
   public static InventoryUI Instance;
   [SerializeField] private GameObject inventory;
   [SerializeField] private GameObject confirmButton;
   [SerializeField] private GameObject itemPrefab;
   [SerializeField] private Transform content;
   [SerializeField] private List<GridSO> itemsList;

   private GridSO currentGrid;
   private GridSO placedGrid;
   
   public void Awake()
   {
      if (Instance != null && Instance != this)
      {
         Destroy(this.gameObject);
         return;
      }
      Instance = this;
      
      
      UpdateInventory();
   }

   public void SetCurrentGrid(GridSO grid)
   {
      currentGrid = grid;
   }

   private void UpdateInventory()
   {
      //remove old item
      foreach (Transform child in content)
      {
             Destroy(child.gameObject);
      }
      //refresh items
      foreach (var item in itemsList)
      {
         GenerateItemsInInventory(item);
      }
   }

   
   

   public void OpenInventory()
   {
      if (inventory.activeSelf)
      {
         inventory.SetActive(false);
         Hide();
         return;
      }
      inventory.SetActive(true);
      UpdateInventory();
      CharacterUI.Instance.Hide();
      
   }
   
   public void Hide()
   {
      inventory.SetActive(false);
      confirmButton.SetActive(false);
   }

   //plce the grid on current grid
   public void Place()
   {
      GridManager.Instance.Place(placedGrid);
      //remove the placed frid from bag
      RemoveItem(placedGrid);
      //add the grid take back from map
      AddItem(currentGrid);
      currentGrid = null;
      placedGrid = null;
      
      UpdateInventory();
      confirmButton.SetActive(false);
      inventory.SetActive(false);
   }

   public void PutItem(GridSO grid)
   {
      AddItem(grid);
      currentGrid = null;
      placedGrid = null;
      UpdateInventory();
   }

   public void ConfirmPlace(GridSO grid)
   {
      confirmButton.SetActive(true);
      placedGrid = grid;
   }

   public void AddItem(GridSO grid)
   {
      if (!grid) return;
      itemsList.Add(grid);
      
   }

   public void RemoveItem(GridSO grid)
   {
      if (!grid) return;
      itemsList.Remove(grid);
   }

   public void GenerateItemsInInventory(GridSO grid)
   { 
     GameObject go = Instantiate(itemPrefab, content.transform);
     go.transform.SetParent(content);
     go.GetComponent<ItemInventoryUI>().IniteItemUI(grid);

   }
}
