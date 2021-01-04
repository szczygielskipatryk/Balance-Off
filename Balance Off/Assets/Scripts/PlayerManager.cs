using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool IsAlive;
    public GameObject gameOver;
    void Start()
    {
        IsAlive = true;
        Time.timeScale = 1;
    }

    
    void Update()
    {
        if (!IsAlive)
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }
}
