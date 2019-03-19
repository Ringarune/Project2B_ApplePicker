using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// updates text for high score chart
/// </summary>
public class Highscores : MonoBehaviour
{
    //variables
    //text objects
    public Text Score1;
    public Text Score2;
    public Text Score3;
    public Text Score4;
    public Text Score5;
    public Text Score6;
    public Text Score7;
    public Text Score8;
    public Text Score9;
    public Text Score10;

    // Start is called before the first frame update
    void Start()
    {
        //update text
        Score1.text = "1. " + PlayerPrefs.GetInt("highscore1", 0);
        Score2.text = "2. " + PlayerPrefs.GetInt("highscore2", 0);
        Score3.text = "3. " + PlayerPrefs.GetInt("highscore3", 0);
        Score4.text = "4. " + PlayerPrefs.GetInt("highscore4", 0);
        Score5.text = "5. " + PlayerPrefs.GetInt("highscore5", 0);
        Score6.text = "6. " + PlayerPrefs.GetInt("highscore6", 0);
        Score7.text = "7. " + PlayerPrefs.GetInt("highscore7", 0);
        Score8.text = "8. " + PlayerPrefs.GetInt("highscore8", 0);
        Score9.text = "9. " + PlayerPrefs.GetInt("highscore9", 0);
        Score10.text = "10. " + PlayerPrefs.GetInt("highscore10", 0);
    }
}
