using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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

        // Detect tap
        touchControls.Touch.TouchPress.started += StartTouch;
        touchControls.Touch.TouchPress.canceled += EndTouch;

        // Detect hold
        touchControls.Touch.TouchHold.performed += HoldTouch;
    }

    private void OnDisable()
    {
        touchControls.Touch.TouchPress.started -= StartTouch;
        touchControls.Touch.TouchPress.canceled -= EndTouch;
        touchControls.Touch.TouchHold.performed -= HoldTouch;
        touchControls.Disable();
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        // Touching the screen and finding the position
        Vector2 touchPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
        Debug.Log($"Touched the screen at (screen space): {touchPosition}");

        // Convert screen position to world position
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(touchPosition);
        Debug.Log($"Converted to world position: {worldPoint}");

        // Check if the touch is over a UI element
        if (IsPointerOverUI(touchPosition))
        {
            Debug.Log("Touched a UI element!");
            return;  // Skip processing if it's a UI element
        }

        // Perform raycast
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        // Debug the result of the raycast
        if (hit.collider != null)
        {
            Debug.Log($"Raycast hit: {hit.collider.gameObject.name}");

            // Check if the hit object has InteractiveObjects script
            InteractiveObjects interactive = hit.collider.GetComponent<InteractiveObjects>();
            if (interactive != null)
            {
                Debug.Log("Interactive object found!");
                interactive.ShowInfo();
            }
            else
            {
                Debug.Log("No InteractiveObjects script on the touched object.");
            }
        }
        else
        {
            Debug.Log("Raycast did not hit any object.");
        }

        // Start dragging
        startTouchPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        //Debug.Log("Stopped touching screen");

        endTouchPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
        Vector2 swipeDelta = endTouchPosition - startTouchPosition;

        if (swipeDelta.magnitude > 50f) // Adjust sensitivity
        {
            //Debug.Log("Swiped: " + swipeDelta);
            // Trigger room transition or other event
        }
    }

    private void HoldTouch(InputAction.CallbackContext context)
    {
        // Uncomment for holding functionality (if needed)
        // Debug.Log("Holding touch on object...");
    }

    private bool IsPointerOverUI(Vector2 touchPosition)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = touchPosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;  // Return true if pointer is over any UI element
    }
}