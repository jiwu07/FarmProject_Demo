using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = System.Random;

public class DecorationGrid : GridBase
{
    [SerializeField] private GridSO groundSO;
    private DecorationSO DecorationSO; //for extend, maybe can have more similar building
    private int clickTime = 0;
    private int triggerTime = 1;

    private int something, treat = 1;
    


    public void init(DecorationSO decoSO)
    {
        this.DecorationSO = decoSO;
    }

    /// <summary>
    /// just for fun this object
    /// </summary>
    /// <param name="playerAgent"></param>
    public override void Interact(UnityEngine.AI.NavMeshAgent playerAgent)
    {
        //add costmoney logic and maybe also a text of sum of the money spend on this lotto
        clickTime++;
        //seems like no interact at all
        if (clickTime == 0)
        {
            NotificationUI.Instance.Show("Click "+triggerTime.ToString()+ " times to get something!");
        }
        else
        {
            NotificationUI.Instance.Show("Click " + clickTime.ToString() );
        }
        
        

        if (clickTime >= triggerTime)
        {
            clickTime = 0;
            triggerTime = UnityEngine.Random.Range(2, 7);
            //something happen
            int something = UnityEngine.Random.Range(1, 5);
            int treat = UnityEngine.Random.Range(0, 20);
            
            switch (something)
            {
                case 1:
                    CoinManager.Instance.AddCoin(treat);
                    NotificationUI.Instance.Show("You got " + treat.ToString() + " Coins!");
                    break;
                case 2:
                    CoinManager.Instance.SubtractCoin(treat);
                    NotificationUI.Instance.Show("You lose " + treat.ToString() + " Coins!");
                    break;
                case 3:
                    InventoryUI.Instance.AddItem(groundSO);
                    NotificationUI.Instance.Show("You got a Land!");
                    break;
                default:
                    NotificationUI.Instance.Show("Oh, nothing happened!");
                    break;
                
            }
        }
    }

}
