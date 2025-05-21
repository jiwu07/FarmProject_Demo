using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TaskDetailUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI taskName;
    [SerializeField] private TextMeshProUGUI taskDescription;
    [SerializeField] private TextMeshProUGUI taskProgress;
    [SerializeField] private GameObject acceptButton;
    [SerializeField] private GameObject submitButton;

    private CoinTaskSO taskSO;

    private int startCoin = 0;
    private int currentCoin = 0;
    private int taskNeed ;
    private bool isAccepted = false;

    public void Init(CoinTaskSO taskSO)
    {
        taskName.text = taskSO.name;
        taskDescription.text = taskSO.taskDescription;
        taskNeed = taskSO.taskObjectNeed;
        this.taskSO = taskSO;
    }

    public void AcceptTask()
    {
        taskProgress.gameObject.SetActive(true);
        acceptButton.SetActive(false);
        startCoin = CoinManager.Instance.GetCurrentCoins();
        currentCoin = 0;
        isAccepted = true;
    }

    void Update()
    {
        if (isAccepted)
        {
            currentCoin = CoinManager.Instance.GetCurrentCoins() - startCoin;
            taskProgress.text = currentCoin.ToString() + "/" + taskNeed.ToString();
            if (currentCoin >= taskNeed)
            {
                submitButton.SetActive(true);

            }
        
        }
    }

    public void SubmitTask()
    {
        taskProgress.gameObject.SetActive(false);
        int temp = taskSO.rewardCoin;
        CoinManager.Instance.AddCoin(temp);
        NotificationUI.Instance.Show("Got Reward " + temp.ToString() + " Coins");
        Destroy(gameObject);
    }
}
