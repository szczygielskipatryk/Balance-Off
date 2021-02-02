using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsEvents : MonoBehaviour
{
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

    public void about()
    {
        SceneManager.LoadScene("About");
    }

    public void setVolume(float volume)
    {
        PlayerPrefs.SetFloat("VolumeMain",volume);
        PlayerPrefs.Save();
    }

    public void control(bool isChecked)
    {
        PlayerPrefs.SetInt("isChecked", isChecked ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void reset()
    {
        PlayerPrefs.SetInt("HighScore",0);
        PlayerPrefs.Save();
    }

}
