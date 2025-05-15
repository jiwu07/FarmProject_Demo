using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.iOS;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public static event Action<Vector2> Click;    private GameControl gameControl;
    
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
        Vector2 screenPos = Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed
            ? Touchscreen.current.primaryTouch.position.ReadValue()
            : Mouse.current.position.ReadValue();

        Click?.Invoke(screenPos); 
    }
}
