using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private TouchControls touchControls;
    private GraphicRaycaster graphicRaycaster;
    private EventSystem eventSystem;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private void Awake()
    {
        touchControls = new TouchControls();

        graphicRaycaster = FindObjectOfType<GraphicRaycaster>();
        eventSystem = FindObjectOfType<EventSystem>();

        if (graphicRaycaster == null)
        {
            Debug.LogError("GraphicRaycaster not found in the scene! Make sure your Canvas has a GraphicRaycaster component.");
        }
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

        // Check if the touch is over a UI element
        GameObject hitObject = GetUIElementAtPosition(touchPosition);
        if (hitObject != null)
        {
            Debug.Log($"Touched UI element: {hitObject.name}");

            // Check if the UI element has an InteractiveObjects component
            InteractiveObjects interactive = hitObject.GetComponentInParent<InteractiveObjects>();
            if (interactive != null)
            {
                Debug.Log("Interactive object found!");
                interactive.ShowInfo();
            }
            else
            {
                Debug.Log($"No InteractiveObjects script found on {hitObject.name} or its parents.");
            }
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

    // Function to detect UI elements at touch position
    private GameObject GetUIElementAtPosition(Vector2 position)
    {
        if (eventSystem == null || graphicRaycaster == null)
        {
            Debug.LogError("EventSystem or GraphicRaycaster is missing!");
            return null;
        }

        PointerEventData eventData = new PointerEventData(eventSystem)
        {
            position = position
        };

        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(eventData, results);

        return results.Count > 0 ? results[0].gameObject : null;
    }
}