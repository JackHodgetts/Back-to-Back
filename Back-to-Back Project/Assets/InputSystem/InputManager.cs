using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private TouchControls touchControls;

    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
        touchControls.Touch.TouchPress.started += StartTouch;
        touchControls.Touch.TouchPress.canceled += EndTouch;
    }

    private void OnDisable()
    {
        touchControls.Touch.TouchPress.started -= StartTouch;
        touchControls.Touch.TouchPress.canceled -= EndTouch;
        touchControls.Disable();
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Vector2 touchPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
        Debug.Log("Touched the screen at: " + touchPosition);
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Stopped touching screen");
    }
}