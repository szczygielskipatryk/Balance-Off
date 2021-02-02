using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText,highScoreText;
    public Transform player;
    [SerializeField] public static float Score;
    [SerializeField] private float HighScore;
    [SerializeField] private Vector3 _lastPos;
    void Start()
    {
        _lastPos = player.position;
        Score = 0;
        HighScore = PlayerPrefs.GetInt("HighScore");
    }

    
    void Update()
    {
        Score = Mathf.Round(Vector3.Distance(_lastPos, player.position));
        scoreText.text = "Score: " + Score;
        highScoreText.text = "High Score: " + HighScore;
        if (Score > HighScore)
        {
            HighScore = Score;
        }
        PlayerPrefs.SetInt("HighScore", (int)HighScore);
        PlayerPrefs.Save();
    }
}
