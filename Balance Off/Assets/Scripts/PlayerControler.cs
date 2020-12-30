using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 dir;
    public float ForwardSpeed;
    private int _line = 1; //0-lewa linia, 1 linia środkowa, 2- prawa linia
    private readonly float _line_distance = 3; // dystans między dwoma liniami
    public bool IsAlive = true;
    private float jump = 10;
    private float gravforce = -20;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        dir.z = ForwardSpeed;
    }

    private void Update()
    {
        
        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
        else
        {
            dir.y += gravforce * Time.deltaTime;
        }
        
        //zmiana linii (narazie za pomocą strzałek, późniejsza implementacja akcelerometry i gestów)
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _line++;
            if (_line == 3)
            {
                IsAlive = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _line--;
            if (_line == -1)
            {
                IsAlive = false;
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

        transform.position = Vector3.Lerp(transform.position,newPosition,120*Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        _controller.Move(dir * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        dir.y = jump;
    }
}
