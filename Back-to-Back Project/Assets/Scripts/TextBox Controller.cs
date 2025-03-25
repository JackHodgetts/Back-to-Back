using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextBoxController : MonoBehaviour
{
    public static TextBoxController instance;
    public GameObject textboxPanal;
    public TextMeshProUGUI textboxText;

    private bool isTextboxVisible = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

        textboxPanal.SetActive(false);
    
        isTextboxVisible = false;
    }

    public void ToggleText(string message)
    {
        if (!isTextboxVisible)
        {
            ShowText(message);
        }
    }

    public void ShowText(string message)
    {
        textboxPanal.SetActive(true);
        textboxText.text = message;
        isTextboxVisible = true;
    }

    public void HideText()
    {
        textboxPanal.SetActive(false);
        isTextboxVisible = false;
    }

    public void LoadTextFromFile(string fileName)
    {
        // Load the text file (ensure it's in the Resources folder)
        TextAsset textAsset = Resources.Load<TextAsset>(fileName);

        if (textAsset != null)
        {
            // Pass the content of the text file to ShowText function
            ShowText(textAsset.text);
        }
        else
        {
            Debug.LogError("Text file not found: " + fileName);
        }
    }
}
