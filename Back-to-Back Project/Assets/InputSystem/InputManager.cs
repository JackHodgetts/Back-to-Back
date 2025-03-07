using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private TouchControls touchControls;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();

        //Tapping on the screen
        touchControls.Touch.TouchPress.started += StartTouch;
        touchControls.Touch.TouchPress.canceled += EndTouch;

        //Holding down on the screen
        touchControls.Touch.TouchPress.started += StartTouch;
        touchControls.Touch.TouchPress.canceled += EndTouch;
        touchControls.Touch.TouchHold.performed += HoldTouch;
    }

    private void OnDisable()
    {
        touchControls.Touch.TouchPress.started -= StartTouch;
        touchControls.Touch.TouchPress.canceled -= EndTouch;
        touchControls.Disable();
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        //Touching the screen and finding the position
        Vector2 touchPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
        Debug.Log("Touched the screen at: " + touchPosition);

        //Dragging on the screen
        startTouchPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();

    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Stopped touching screen");

        endTouchPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
        Vector2 swipeDelta = endTouchPosition - startTouchPosition;

        if (swipeDelta.magnitude > 50f) // Adjust sensitivity
        {
            Debug.Log("Swiped: " + swipeDelta);
            // Trigger room transition or other event
        }
    }

    private void HoldTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Holding touch on object...");
    }
}