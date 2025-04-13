using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveObjects : MonoBehaviour
{

    public string objectInfo; // Assign in Inspector
    public string fileName;
    public string titleName;

    public string newBackgroundName;

    public bool shouldswitchscene = false;

    public void ShowInfo()
    {
        Debug.Log($"ShowInfo called on: {gameObject.name}");

        TextBoxController.instance.ResetScrollPosition();
        TextBoxController.instance.LoadTextFromFile(fileName);
        TextBoxController.instance.LoadTitleFromFile(titleName);

        gameObject.SetActive(false);
    }

    public void Activate()
    {
        Debug.Log($"Activate called on: {gameObject.name}");

        if (shouldswitchscene && !string.IsNullOrEmpty(newBackgroundName))
        {
            Debug.Log($"Attempting to transition scene to background: {newBackgroundName}");
            TextBoxController.instance.TransitionScene(newBackgroundName);
        }
        else
        {
            Debug.LogWarning("Activate called but newBackgroundName is empty or shouldswitchscene is false.");
        }

        gameObject.SetActive(false); // Hide this specific object after use
    }

}
