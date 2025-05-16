using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public static event Action<Vector2> ClickMove;

    private GameControl gameControl;

    void Awake()
    {
        // 单例模式
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;

        // 初始化 Input Actions
        gameControl = new GameControl();
        gameControl.Player.Enable();

        // 注册点击事件
        gameControl.Player.Click.performed += ctx => StartCoroutine(HandleClick());
    }

    void OnDestroy()
    {
        // 解绑事件，防止报错
        if (gameControl != null)
        {
            gameControl.Player.Click.performed -= ctx => StartCoroutine(HandleClick());
        }
    }

    /// <summary>
    /// 点击后延迟一帧判断 UI 状态并传递点击位置
    /// </summary>
    private IEnumerator HandleClick()
    {
        yield return new WaitForEndOfFrame(); // 确保 UI 状态是最新的

        if (IsPointerOverUI())
        {
            Debug.Log("点击在 UI 上，忽略点击");
            yield break;
        }

        Vector2 clickPos = gameControl.Player.Position.ReadValue<Vector2>();
        ClickMove?.Invoke(clickPos); // 分发事件给其他系统
    }

    /// <summary>
    /// 判断当前点击是否在 UI 上
    /// </summary>
    private bool IsPointerOverUI()
    {
        // 触屏设备上判断 UI
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            int touchId = Touchscreen.current.primaryTouch.touchId.ReadValue();
            return EventSystem.current.IsPointerOverGameObject(touchId);
        }

        // 鼠标设备上判断 UI
        return EventSystem.current.IsPointerOverGameObject();
    }
}