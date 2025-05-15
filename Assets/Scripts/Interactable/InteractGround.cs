using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractGround : InteractableObject
{
    private bool isInteractable = true;
    public virtual void OnClick(UnityEngine.AI.NavMeshAgent playerAgent)
    {
        Debug.Log($"{name} InteractGround 土地 被交互了！");
        // 可以扩展为对话、采集、触发事件等
    }
}
