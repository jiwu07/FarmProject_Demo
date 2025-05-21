using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu()]
public class CoinTaskSO : ScriptableObject
{
    public string taskName;
    public string taskDescription;
    public int taskObjectNeed;
    public int rewardCoin;
    public GameObject prefab;

}
