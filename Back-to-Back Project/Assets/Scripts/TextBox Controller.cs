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

    public RawImage backgroundImage;

    private bool isTextboxVisible = false;

    public string startingBackgroundName = "GeorgeSaundersMiddle1";
    public string currentBackgroundName;

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

        if (backgroundImage.texture != null)
        {
            currentBackgroundName = backgroundImage.texture.name;
            ShowOnlyInteractiveObjectsFor(currentBackgroundName);
        }
        else
        {
            Debug.LogWarning("No background texture found on start.");
        }
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
            ShowTitle(textAsset.text);
        }
        else
        {
            Debug.LogError("Title file not found: " + fileName);
        }
    }

    public void ResetScrollPosition()
    {
        ScrollRect scrollRect = textboxPanal.GetComponentInChildren<ScrollRect>();
        if (scrollRect != null)
        {
            scrollRect.verticalNormalizedPosition = 1f;
        }
    }

    public void SwitchBackground(string backgroundFileName)
    {
        Debug.Log($"SwitchBackground called with filename: {backgroundFileName}");

        Texture newBackground = Resources.Load<Texture>("Backgrounds/" + backgroundFileName);
        if (backgroundImage != null && newBackground != null)
        {
            backgroundImage.texture = newBackground;
            currentBackgroundName = backgroundFileName;
            Debug.Log("Background successfully loaded and applied.");
        }
        else
        {
            Debug.LogError("Background not found or image reference is missing.");
        }
    }

    public void TransitionScene(string backgroundFileName)
    {
        Debug.Log($"TransitionScene called with background: {backgroundFileName}");
        SwitchBackground(backgroundFileName);
        HideAllInteractiveObjects();
        ShowOnlyInteractiveObjectsFor(backgroundFileName);
    }

    public void HideAllInteractiveObjects()
    {
        GameObject[] interactiveObjects = GameObject.FindGameObjectsWithTag("Interactive");
        foreach (GameObject obj in interactiveObjects)
        {
            obj.SetActive(false);
        }
    }

    public void ShowOnlyInteractiveObjectsFor(string backgroundName)
    {
        GameObject[] interactiveObjects = GameObject.FindGameObjectsWithTag("Interactive");

        foreach (GameObject obj in interactiveObjects)
        {
            InteractiveObjects interactive = obj.GetComponent<InteractiveObjects>();
            if (interactive != null)
            {
                bool shouldBeActive = interactive.associatedBackground == backgroundName;
                obj.SetActive(shouldBeActive);
            }
        }
    }
}
