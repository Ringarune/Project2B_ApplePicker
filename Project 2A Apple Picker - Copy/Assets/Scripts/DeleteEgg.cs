using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// destroys egg prefab when the egg collides with the ground and keeps track of highscores with playerprefs
/// </summary>
public class DeleteEgg : MonoBehaviour
{
    //variables
    [Header("Text")]
    public Text text;
    private int count = 3;
    [Header("Audio")]
    public AudioSource Sfx;

    //current in game high score tracker
    int HighScore;
    //10 highscore keys
    string ScoreKey1 = "highscore1";
    string ScoreKey2 = "highscore2";
    string ScoreKey3 = "highscore3";
    string ScoreKey4 = "highscore4";
    string ScoreKey5 = "highscore5";
    string ScoreKey6 = "highscore6";
    string ScoreKey7 = "highscore7";
    string ScoreKey8 = "highscore8";
    string ScoreKey9 = "highscore9";
    string ScoreKey10 = "highscore10";

    private void Start()
    {
    }
    //ground prefab collision
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "EGG")
        {
            Destroy(collision.gameObject);
            count -= 1;
            //loads end scene when health reaches zero
            if (count == 0)
            {
                //setting highscore chart
                HighScore = PlayerEgg.count;
                //check if current score higher than #1 score
                if (HighScore > PlayerPrefs.GetInt(ScoreKey1, 0))
                {
                    //cycle through remaining scores to push them down
                    for (int i = 9; i >= 1; i--)
                    {
                        PlayerPrefs.SetInt("highscore" + (i + 1), PlayerPrefs.GetInt("highscore" + i, 0));
                    }
                    //set top highscore
                    PlayerPrefs.SetInt("highscore1", HighScore);
                    PlayerPrefs.Save();
                    PlayerEgg.count = 0;
                        //load end scene
                        SceneManager.LoadScene("End Scene");
                }
                //check if current score is greater than lowest highscore
                else if (HighScore > PlayerPrefs.GetInt(ScoreKey10, 0)) {
                    //loop through scores to set new score in
                    for (int i = 9; i >= 1; i--)
                    {
                        if (PlayerPrefs.GetInt("highscore" + i, 0) < HighScore)
                        {
                            //move down score to lower spot
                            PlayerPrefs.SetInt("highscore" + (i + 1), PlayerPrefs.GetInt("highscore" + i, 0));
                        }
                        //if not larger than next value, then set current score and break loop
                        else
                        {
                            PlayerPrefs.SetInt("highscore" + (i + 1), HighScore);
                            PlayerPrefs.Save();
                            PlayerEgg.count = 0;
                            SceneManager.LoadScene("End Scene");
                            break;
                        }
                    } 
                }
                //if score is 0
                else
                {
                    PlayerEgg.count = 0;
                    SceneManager.LoadScene("End Scene");
                }
            }
            //update text
            text.text = "Health " + count + "/3";
            //sfx
            Sfx.Play();
        }
    }
}
