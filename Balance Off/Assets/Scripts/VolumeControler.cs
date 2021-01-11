using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControler : MonoBehaviour
{
    public AudioMixer mixer;
    void Start()
    {
        mixer.SetFloat("VolumeMain", PlayerPrefs.GetFloat("VolumeMain"));
    }
}
