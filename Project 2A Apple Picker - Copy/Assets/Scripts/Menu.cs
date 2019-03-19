using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// controls visibility of in-game menu and saves sound settings to playerprefs (mute toggles & slider values)
/// </summary>
public class Menu : MonoBehaviour
{
    //testing merging
    public static int counter = 0;
    //variables
    public GameObject screen;

    //mute toggles
    [Header("Toggles")]
    public Toggle MusicMuteToggle;
    public Toggle MusicSFXToggle;

    //music gameobject
    [Header("Audio")]
    public AudioSource Music;
    public AudioSource SFX1;
    public AudioSource SFX2;

    //slider objects
    [Header("Sliders")]
    public Slider MusicSlider;
    public Slider SFXSlider;

    // Start is called before the first frame update
    void Start()
    {
        //makes main menu invisible
        screen.transform.localScale = new Vector3(0, 0, 0);

        //sets Music sliders to current volume 
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            MusicSlider.value = Music.volume;
        }

        //sets SFX sliders to current volume 
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }
        else
        {
            SFXSlider.value = SFX1.volume;
        }

        //sets toggles for muting to be off
        //checks player preferences for volume
        if (PlayerPrefs.HasKey("Music")) {
            if (PlayerPrefs.GetInt("Music") == 1)
            {
                Music.volume = MusicSlider.value;
                MusicMuteToggle.isOn = false;
            }
            else if (PlayerPrefs.GetInt("Music") == 0)
            {
                Music.volume = 0;
                MusicMuteToggle.isOn = true;
            }
        }
        else {
            MusicMuteToggle.isOn = false;
        }

        //SFX toggle preferences
        if (PlayerPrefs.HasKey("SFX"))
        {
            if (PlayerPrefs.GetInt("SFX") == 1)
            {
                SFX1.volume = SFXSlider.value;
                SFX2.volume = SFXSlider.value;
                MusicSFXToggle.isOn = false;
            }
            else if (PlayerPrefs.GetInt("SFX") == 0)
            {
                SFX1.volume = 0;
                SFX2.volume = 0;
                MusicSFXToggle.isOn = true;
            }
        }
        else
        {
            MusicSFXToggle.isOn = false;
        }
    }

    //makes menu visible/invisible on click
    public void OpenMenu()
    {
        //makes main menu visible
        if (counter == 0)
        {
            screen.transform.localScale = new Vector3(1, 1, 1);
            counter = 1;
        }
        //makes menu invisible
        else
        {
            screen.transform.localScale = new Vector3(0, 0, 0);
            counter = 0;
        }

    }

    //mutes/unmutes music
    public void MuteMusic()
    {
        //if toggle is turned on
        if (MusicMuteToggle.isOn == false)
        {
            Music.volume = MusicSlider.value;
            PlayerPrefs.SetInt("Music", 1);
            PlayerPrefs.Save();
        }
        //if toggle is turned off
        if (MusicMuteToggle.isOn == true)
        {
            Music.volume = 0;
            PlayerPrefs.SetInt("Music", 0);
            PlayerPrefs.Save();
        }
    }

    //mutes/unmutes SFX
    public void MuteSFX()
    {
        //if toggle is turned on
        if (MusicSFXToggle.isOn == false)
        {
            SFX1.volume = 1;
            SFX2.volume = 1;
            PlayerPrefs.SetInt("SFX", 1);
            PlayerPrefs.Save();
        }
        //if toggle is turned off
        if (MusicSFXToggle.isOn == true)
        {
            SFX1.volume = 0;
            SFX2.volume = 0;
            PlayerPrefs.SetInt("SFX", 0);
            PlayerPrefs.Save();
        }
    }

    //Controls Music Slider
    public void MusicSliderVolume()
    {
        //checks if mute not already activated
        if (MusicMuteToggle.isOn == false)
        {
            Music.volume = MusicSlider.value;
            PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
            PlayerPrefs.Save();
        }
        //even if muted saves value of slider
        else if (MusicMuteToggle.isOn == true)
        {
            PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
            PlayerPrefs.Save();
        }
    }

    //Controls SFX Slider
    public void SFXSliderVolume()
    {
        //checks if mute not already activated
        if (MusicSFXToggle.isOn == false)
        {
            SFX1.volume = SFXSlider.value;
            SFX2.volume = SFXSlider.value;
            PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
            PlayerPrefs.Save();
        }
        //even if muted saves value of slider
        else if (MusicSFXToggle.isOn == true)
        {
            PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
            PlayerPrefs.Save();
        }
    }
}
