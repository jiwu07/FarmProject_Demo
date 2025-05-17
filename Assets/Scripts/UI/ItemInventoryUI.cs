using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryUI : MonoBehaviour
{
    [SerializeField]private Image icon;
    private GridSO gridItem;
    public void IniteItemUI(GridSO itemSO)
    {
        this.gridItem = itemSO;
        this.icon.sprite = itemSO.iconSprite;
    }

    public void ConfirmPlace()
    {
        if(!PlaceModeManager.instance.IsPlaceModeOn()) return;
        GridManager.Instance.ConfirmPlace(gridItem);
    }
}
