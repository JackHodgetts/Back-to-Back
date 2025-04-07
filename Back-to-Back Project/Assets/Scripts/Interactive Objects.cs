using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveObjects : MonoBehaviour
{

    public string objectInfo; // Assign in Inspector
    public string fileName;
    public string titleName;

    public void ShowInfo()
    {
        TextBoxController.instance.ResetScrollPosition();
        TextBoxController.instance.LoadTextFromFile(fileName);
        TextBoxController.instance.LoadTitleFromFile(titleName);
    }

}
