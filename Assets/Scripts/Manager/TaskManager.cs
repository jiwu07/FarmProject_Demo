using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField]private List<CoinTaskSO> coinTasks = new List<CoinTaskSO>();
    [SerializeField] private Transform taskList;
    [SerializeField] private TextMeshProUGUI taskCountText;
    
    private float timer = 0;
    private float duration = 5f;
    public void Interact(UnityEngine.AI.NavMeshAgent playerAgent)
    {
        //Open TaskUI
        taskList.parent.gameObject.SetActive(true);
    }

    public void GiveTask()
    {
        //if taskUI got no task anymore then give some task to show
        CoinTaskSO task = coinTasks[Random.Range(0, coinTasks.Count)];
        GameObject go = Instantiate(task.prefab,taskList);
        go.GetComponent<TaskDetailUI>().Init(task);
        
    }

    public void Update()
    {
        //here need a timer to get a cool down time for give task, also need ui to show the timer
        
        if (taskList.childCount == 0)
        {
            if(!taskCountText.gameObject.activeSelf)taskCountText.gameObject.SetActive(true);
            if (timer >= duration)
            {
                timer = 0;
                GiveTask();
                taskCountText.gameObject.SetActive(false);
            }
           timer += Time.deltaTime;
           taskCountText.text = Mathf.CeilToInt(duration - timer).ToString();
        }
       
    }
}
