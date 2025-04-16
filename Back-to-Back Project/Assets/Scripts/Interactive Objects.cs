using UnityEngine;

public class InteractiveObjects : MonoBehaviour
{
    public string fileName;
    public string titleName;

    public void ShowInfo()
    {
        TextBoxController.instance.ResetScrollPosition();
        TextBoxController.instance.LoadTextFromFile(fileName);
        TextBoxController.instance.LoadTitleFromFile(titleName);

        gameObject.SetActive(false); // Hide/delete this object after being pressed
    }
}
