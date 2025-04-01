using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveObjects : MonoBehaviour
{

    public string objectInfo; // Assign in Inspector
    public string fileName;

    public void ShowInfo()
    {
        TextBoxController.instance.LoadTextFromFile(fileName);
    }

}
