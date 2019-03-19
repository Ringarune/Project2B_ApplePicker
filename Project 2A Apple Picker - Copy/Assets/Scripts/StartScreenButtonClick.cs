using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Has functions for button presses on start menu
/// </summary>
public class StartScreenButtonClick : MonoBehaviour
{
    //change scene when press start button
    public void StartButton()
    {
        SceneManager.LoadScene("Start Scene");
    }
    //quits application
    public void Quit()
    {
        Application.Quit();
    }
    //changes scene to main menu start screen
    public void MainMenu()
    {
        SceneManager.LoadScene("Intro Scene");
    }
}
