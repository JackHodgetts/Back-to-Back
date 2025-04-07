using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class TextBoxController : MonoBehaviour
{
    public static TextBoxController instance;
    public GameObject textboxPanal;
    public TextMeshProUGUI textboxText;
    public TextMeshProUGUI textboxTitle;

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

    public void ShowTitle(string title)
    {
        textboxPanal.SetActive(true);
        textboxTitle.text = title;
        isTextboxVisible = true;
    }

    public void HideText()
    {
        textboxPanal.SetActive(false);
        isTextboxVisible = false;
    }

    public void LoadTextFromFile(string fileName)
    {
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

    public void LoadTitleFromFile(string fileName)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(fileName);

        if (textAsset != null)
        {
            // Pass the content of the text file to ShowText function
            ShowTitle(textAsset.text);
        }
        else
        {
            Debug.LogError("Text file not found: " + fileName);
        }
    }

    public void ResetScrollPosition()
    {
        // Find the ScrollRect component and reset the scroll position to the top
        ScrollRect scrollRect = textboxPanal.GetComponentInChildren<ScrollRect>();
        if (scrollRect != null)
        {
            scrollRect.verticalNormalizedPosition = 1f; // Reset to top
        }
    }
}
