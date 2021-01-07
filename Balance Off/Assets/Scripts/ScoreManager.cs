using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Transform player;
    [SerializeField] private float score = 0;
    [SerializeField] private Vector3 _lastPos;
    void Start()
    {
        _lastPos = player.position;
    }

    
    void Update()
    {
        score += Mathf.Round(player.position.z - _lastPos.z);
        _lastPos = player.position;
        if ((int)score % 50 == 0)
        {
            PlayerControler.ForwardSpeed += 20;
        }
        scoreText.text = "Score: " + score;
    }
}
