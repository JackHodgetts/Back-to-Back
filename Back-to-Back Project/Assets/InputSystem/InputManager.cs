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
    private ScrollRect activeScrollRect;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool isScrolling = false;

    private void Awake()
    {
        touchControls = new TouchControls();

        graphicRaycaster = FindObjectOfType<GraphicRaycaster>();
        eventSystem = FindObjectOfType<EventSystem>();

    }

    private void OnEnable()
    {
        touchControls.Enable();

        // Detect tap
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
        // Touching the screen and finding the position
        Vector2 touchPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
        Debug.Log($"Touch started at: {touchPosition}");


        // Check if the touch is over a UI element
        GameObject hitObject = GetUIElementAtPosition(touchPosition);
        if (hitObject != null)
        {

            Debug.Log($"Hit UI element: {hitObject.name}");

            // Check if it's a ScrollRect
            ScrollRect scrollRect = hitObject.GetComponentInParent<ScrollRect>();
            if (scrollRect != null)
            {
                Debug.Log("Touch detected on a ScrollRect");
                isScrolling = true;
                return;
            }

            // Check if the UI element has an InteractiveObjects component
            if (!isScrolling)
            {
                InteractiveObjects interactive = hitObject.GetComponentInParent<InteractiveObjects>();
                if (interactive != null)
                {
                    Debug.Log($"Interactive object found: {interactive.name}");
                    Debug.Log($"shouldswitchscene: {interactive.shouldswitchscene}, fileName: {interactive.fileName}");
                    if (interactive.shouldswitchscene && string.IsNullOrEmpty(interactive.fileName))
                    {
                        Debug.Log("Calling Activate() for background-only interaction.");
                        interactive.Activate(); // Only swap background
                    }
                    else
                    {
                        Debug.Log("Calling ShowInfo() for regular interactive.");
                        interactive.ShowInfo(); // Show text and maybe switch background
                    }
                }
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

        isScrolling = false;
    }

    // Function to detect UI elements at touch position
    private GameObject GetUIElementAtPosition(Vector2 position)
    {
        PointerEventData eventData = new PointerEventData(eventSystem) { position = position };
        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(eventData, results);
        return results.Count > 0 ? results[0].gameObject : null;
    }
}