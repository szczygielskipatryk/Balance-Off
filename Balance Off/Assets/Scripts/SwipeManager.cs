using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    public static bool tap, left, right, up;
    private Vector3 lt, ft;
    private void Update()
    {
        tap= left= right= up = false;
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                ft = touch.position;
                lt = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                lt = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                lt = touch.position;
                if (Mathf.Abs(lt.x - ft.x) > Mathf.Abs(lt.y - ft.y))
                {
                    if (lt.x > ft.x)
                    {
                        //Swipetype 1=right, 2=left, 3=up/tap
                        right = true;
                    }
                    else
                    {
                        left = true;
                    }
                }

                else if (lt.y > ft.y)
                {
                    up = true;
                }
            }
            else
            {
                up = true;
            }
        }

    }
}
