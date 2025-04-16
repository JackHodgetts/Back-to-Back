using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //Loads the menu for each house
    public void LoadLevyMenu()
    {
        SceneManager.LoadScene("Levy_MainMenu");
    }

    public void LoadOldfieldMenu()
    {
        SceneManager.LoadScene("Oldfields_MainMenu");
    }

    public void LoadMitchellsMenu()
    {
        SceneManager.LoadScene("Mitchells_MainMenu");
    }

    public void LoadGeorgeSaundersMenu()
    {
        SceneManager.LoadScene("GeorgeSaunders_MainMenu");
    }

    //Loads the video for floor one for each house
    public void LoadLevysFloorOne()
    {
        SceneManager.LoadScene("Levys_V_FirstFloor");
    }
    public void LoadOldfieldsFloorOne()
    {
        SceneManager.LoadScene("Oldfields_V_FirstFloor");
    }
    public void LoadMitchellsFloorOne()
    {
        SceneManager.LoadScene("Mitchells_V_FirstFloor");
    }
    public void LoadGeorgeSaundersFloorOne()
    {
        SceneManager.LoadScene("George Saunders_V_FirstFloor");
    }

    //Loads the video for floor two for each house
    public void LoadLevysFloorTwo()
    {
        SceneManager.LoadScene("Levys_V_SecondFloor");
    }
    public void LoadOldfieldsFloorTwo()
    {
        SceneManager.LoadScene("Oldfields_V_SecondFloor");
    }
    public void LoadMitchellsFloorTwo()
    {
        SceneManager.LoadScene("Mitchells_V_SecondFloor");
    }
    public void LoadGeorgeSaundersFloorTwo()
    {
        SceneManager.LoadScene("George Saunders_V_SecondFloor");
    }

    //Loads the video for floor three for each house
    public void LoadLevysFloorThree()
    {
        SceneManager.LoadScene("Levy_V_ThirdFloor");
    }
    public void LoadOldfieldsFloorThree()
    {
        SceneManager.LoadScene("Oldfields_V_ThirdFloor");
    }
    public void LoadMitchellsFloorThree()
    {
        SceneManager.LoadScene("Mitchells_V_ThirdFloor");
    }
    public void LoadGeorgeSaundersFloorThree()
    {
        SceneManager.LoadScene("George Saunders_V_ThirdFloor");
    }
    public void LoadLevysTimeCapsule()
    {
        SceneManager.LoadScene("Levy_V_TimeCapsule");
    }

    //Next and back buttons
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    //Exit button that goes to the main menu
    public void ExitToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //Loads the privy and the courtyard from the Main menu
    public void LoadCourtyard()
    {
        SceneManager.LoadScene("Courtyard_V");
    }
    public void LoadPrivy()
    {
        SceneManager.LoadScene("Privy_V");
    }

    //Back buttons that go to house main menu

    public void LoadGerogeMiddleFloor2()
    {
        SceneManager.LoadScene("George Saunders MiddleFloor2");
    }
    
}
