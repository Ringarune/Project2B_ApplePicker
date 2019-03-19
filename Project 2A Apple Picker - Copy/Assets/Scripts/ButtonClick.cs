using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Loads Scenes With Button Click
/// </summary>
public class ButtonClick : MonoBehaviour
{
    public void Click ()
    {
        SceneManager.LoadScene("Start Scene");
    }
    //loads highscore menu
    public void Click2()
    {
        SceneManager.LoadScene("Highscores");
    }
    //loads main menu from highscore menu
    public void Click3()
    {
        SceneManager.LoadScene("Intro Scene");
    }
}
