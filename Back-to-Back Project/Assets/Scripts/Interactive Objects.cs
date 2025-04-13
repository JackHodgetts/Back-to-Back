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
    public string associatedBackground;

    public bool shouldswitchscene = false;

    public void ShowInfo()
    {

        TextBoxController.instance.ResetScrollPosition();
        TextBoxController.instance.LoadTextFromFile(fileName);
        TextBoxController.instance.LoadTitleFromFile(titleName);

        gameObject.SetActive(false);
    }

    public void Activate()
    {

        if (shouldswitchscene && !string.IsNullOrEmpty(newBackgroundName))
        {
            TextBoxController.instance.TransitionScene(newBackgroundName);
        }

        gameObject.SetActive(false); // Hide this specific object after use
    }

}
