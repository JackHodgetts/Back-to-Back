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
    private bool isScrolling = false;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private void Awake()
    {
        touchControls = new TouchControls();
        graphicRaycaster = FindObjectOfType<GraphicRaycaster>();
        eventSystem = FindObjectOfType<EventSystem>();
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
        GameObject hitObject = GetUIElementAtPosition(touchPosition);

        if (hitObject != null)
        {
            ScrollRect scrollRect = hitObject.GetComponentInParent<ScrollRect>();
            if (scrollRect != null)
            {
                isScrolling = true;
                return;
            }

            if (!isScrolling)
            {
                InteractiveObjects interactive = hitObject.GetComponentInParent<InteractiveObjects>();
                if (interactive != null)
                {
                    interactive.ShowInfo();
                }
            }
        }

        startTouchPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        endTouchPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
        isScrolling = false;
    }

    private GameObject GetUIElementAtPosition(Vector2 position)
    {
        PointerEventData eventData = new PointerEventData(eventSystem) { position = position };
        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(eventData, results);
        return results.Count > 0 ? results[0].gameObject : null;
    }
}
