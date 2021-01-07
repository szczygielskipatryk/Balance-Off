using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEvents : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void quit()
    {
        Application.Quit();
    }
}
