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
    public void back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("VolumeMain",volume);
    }

    public void control(bool isChecked)
    {
        chooseControl = isChecked;
        Debug.Log(chooseControl);
    }

}
