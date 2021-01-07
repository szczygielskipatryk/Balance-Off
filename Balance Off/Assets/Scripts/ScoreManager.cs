using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Transform player;
    [SerializeField] public static float Score;
    [SerializeField] private Vector3 _lastPos;
    void Start()
    {
        _lastPos = player.position;
        Score = 1;
    }

    
    void Update()
    {
        Score += Mathf.Round(player.position.z - _lastPos.z);
        _lastPos = player.position;
        scoreText.text = "Score: " + Score;
    }
}
