using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.iOS;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public static event Action<Vector2> ClickMove;   
    private GameControl gameControl;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        gameControl = new GameControl();
        gameControl.Player.Enable();

        gameControl.Player.Click.performed += HandleClick;

    }
    
    

    private void HandleClick(InputAction.CallbackContext context)
    {
        //Better add an check if click on UI and if yes then todo
        if (IsPointerOverUI())
        {
            //Debug.Log("PointerOverUI");
            return;
        }
        //click on the ground here        
        Vector2 screenPos = Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed
            ? Touchscreen.current.primaryTouch.position.ReadValue()
            : Mouse.current.position.ReadValue();

        ClickMove?.Invoke(screenPos); 
    }
    
    private bool IsPointerOverUI()
    {
        // 鼠标
        if (Mouse.current != null)
        {
            return EventSystem.current.IsPointerOverGameObject();
        }

        // 触屏（必须传 fingerId）
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            int fingerId = Touchscreen.current.primaryTouch.touchId.ReadValue();
            return EventSystem.current.IsPointerOverGameObject(fingerId);
        }

        return false;
    }
}
