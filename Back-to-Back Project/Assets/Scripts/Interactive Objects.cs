using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveObjects : MonoBehaviour
{

    public string objectInfo = "Default object information"; // Assign in Inspector

    public void ShowInfo()
    {
        Debug.Log("Showing info: " + objectInfo);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
