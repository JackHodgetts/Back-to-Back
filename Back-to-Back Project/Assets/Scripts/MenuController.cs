using System.Collections;
using System.Collections.Generic;
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
        SceneManager.LoadScene("Levy_V_FloorOne");
    }
    public void LoadOldfieldsFloorOne()
    {
        SceneManager.LoadScene("Oldfields_V_FloorOne");
    }
    public void LoadMitchellsFloorOne()
    {
        SceneManager.LoadScene("Mitchells_V_FloorOne");
    }
    public void LoadGeorgeSaundersFloorOne()
    {
        SceneManager.LoadScene("GeorgeSaunders_V_FloorOne");
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
        SceneManager.LoadScene("GeorgeSaunders_V_SecondFloor");
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
        SceneManager.LoadScene("GeorgeSaunders_V_ThirdFloor");
    }

}
