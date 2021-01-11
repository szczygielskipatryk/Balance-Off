using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    public static bool tap, left, right, up, isDraging;
    private Vector2 lt, ft;
    private void Update()
    {
        tap= left= right= up = false;
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                ft = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        lt = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length < 0)
                lt = Input.touches[0].position - ft;
            else if (Input.GetMouseButton(0))
                lt = (Vector2)Input.mousePosition - ft;
        }

        if (lt.magnitude > 100)
        {
            float x = lt.x;
            float y = lt.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                    left = true;
                else
                    right = true;
            }
            else if (y > 0)

            {
                up = true;

            }

            Reset();
        }

    }

    private void Reset()
    {
        lt = ft = Vector2.zero;
        isDraging = false;
    }
}

