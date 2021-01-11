using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 dir;
    private int _line = 1; //0-lewa linia, 1 linia środkowa, 2- prawa linia
    private readonly float _line_distance = 3; // dystans między dwoma liniami
    private float jump = 10;
    private float gravforce = -20;
    public float forSpeed, maxSpeed;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        dir.z = forSpeed;
        
    }

    void Update()
    {
        if (forSpeed < maxSpeed)
        {
            forSpeed += 0.4f * Time.deltaTime;
        }

        dir.z = forSpeed;

        if (_controller.isGrounded)
        {
            if (SwipeManager.up || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
        else
        {
            dir.y += gravforce * Time.deltaTime;
        }

        //zmiana linii (narazie za pomocą strzałek, późniejsza implementacja akcelerometru i gestów)
        if (SwipeManager.right || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _line++;
            if (_line >= 3)
            {
                PlayerManager.IsAlive = false;
            }
        }

        if (SwipeManager.left || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _line--;
            if (_line <= -1)
            {
                PlayerManager.IsAlive = false;
            }
        }

        //liczenie położenia
        Vector3 newPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (_line == 0)
        {
            newPosition += Vector3.left * _line_distance;
        }
        else if (_line == 2)
        {
            newPosition += Vector3.right * _line_distance;
        }

        //naprawa poruszania się, brak kolizji z pachołkami drogowymi
        if (transform.position == newPosition)
            return;
        Vector3 difference = newPosition - transform.position;
        Vector3 movDirection = difference.normalized * 25 * Time.deltaTime;
        if (movDirection.sqrMagnitude < difference.sqrMagnitude)
            _controller.Move(movDirection);
        else
            _controller.Move(difference);

    }

    void FixedUpdate() { 

    _controller.Move(dir * Time.deltaTime);
    }

    private void Jump()
    {
        dir.y = jump;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "obsticle")
        {
            PlayerManager.IsAlive = false;
        }
    }



}