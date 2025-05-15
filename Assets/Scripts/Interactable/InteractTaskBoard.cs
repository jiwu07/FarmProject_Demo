using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTaskBoard : MonoBehaviour
{
    public virtual void OnClick(UnityEngine.AI.NavMeshAgent playerAgent)
    {
        Debug.Log($"{name} taskboard 被交互了！");
        // 可以扩展为对话、采集、触发事件等
    }
}
