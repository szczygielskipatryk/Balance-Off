using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsEvents : MonoBehaviour
{
    public AudioMixer audioMixer;
    public static bool chooseControl;
    public Slider slider;
    public Toggle toggle;

     void Start()
     {
         slider.value = PlayerPrefs.GetFloat("VolumeMain");
         if (PlayerPrefs.GetInt("isChecked") == 0)
         {
             toggle.isOn = false;
         }
         else if (PlayerPrefs.GetInt("isChecked") == 1)
         {
            toggle.isOn = true;
         }
     }

    public void back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void setVolume(float volume)
    {
        PlayerPrefs.SetFloat("VolumeMain",volume);
        PlayerPrefs.Save();
    }

    public void control(bool isChecked)
    {
        if (PlayerPrefs.GetInt("isChecked") == 0)
        {
            PlayerPrefs.SetInt("isChecked", 1);
        }
        else if (PlayerPrefs.GetInt("isChecked") == 1)
        {
            PlayerPrefs.SetInt("isChecked", 0);
        }
    }

    public void reset()
    {
        PlayerPrefs.SetInt("HighScore",0);
        PlayerPrefs.Save();
    }

}
