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
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;

        gameControl = new GameControl();
        gameControl.Player.Enable();

        gameControl.Player.Click.performed += ctx => StartCoroutine(HandleClick());
    }

    void OnDestroy()
    {
        if (gameControl != null)
        {
            gameControl.Player.Click.performed -= ctx => StartCoroutine(HandleClick());
        }
    }

    /// <summary>
    /// delayed UI status
    /// </summary>
    private IEnumerator HandleClick()
    {
        //make sure UI status is newest
        yield return new WaitForEndOfFrame(); 

        if (IsPointerOverUI())
        {
            //Debug.Log("uiiii");
            yield break;
        }

        Vector2 clickPos = gameControl.Player.Position.ReadValue<Vector2>();
        ClickMove?.Invoke(clickPos); 
    }


    private bool IsPointerOverUI()
    {
        // touchscreen
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            int touchId = Touchscreen.current.primaryTouch.touchId.ReadValue();
            return EventSystem.current.IsPointerOverGameObject(touchId);
        }

        // mouse
        return EventSystem.current.IsPointerOverGameObject();
    }
}