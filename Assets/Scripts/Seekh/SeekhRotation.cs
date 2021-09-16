using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SeekhRotation : MonoBehaviour
{
    Touch touch;
    float maxRightAngle = 30;
    float touchMargin = 10;

    //THIS IS THE HIGHEST DELTA I COULD GET BY SWIMPING THE SCREEN REALLY FAST. THIS VALUE CORRESPONDS TO THE touch.deltaPosition
    float maxDelta = 100;

    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                //Debug.Log(touch.deltaPosition);

                //IF DELTA POSITION IS MAX DELTA, ROTATE IT TO MAX ANGLE, THE RATIO OF ROTATION IS DETERMINED BY THE DELTA POSITION
                if(touch.deltaPosition.x < -touchMargin)
                {
                    float angle = (-maxRightAngle * touch.deltaPosition.x) / -maxDelta;
                    //Debug.Log(angle);
                    rotateLeft(angle);
                }
                else if(touch.deltaPosition.x > touchMargin)
                {
                    float angle = (maxRightAngle * touch.deltaPosition.x) / maxDelta;
                    //Debug.Log(angle);
                    rotateRight(angle);
                }
                else
                {
                    rotateReset();
                }

            }
            else if(touch.phase == TouchPhase.Ended)
            {
                rotateReset();
            }
        }
    }

    void rotateLeft(float angle)
    {
        transform.DORotate(new Vector3(0, angle, 0), 1f);
    }

    void rotateRight(float angle)
    {
        transform.DORotate(new Vector3(0, angle, 0), 1f);
    }

    void rotateReset()
    {
        //Debug.Log("RESET");
        transform.DORotate(new Vector3(0, 0, 0), 0.25f);
    }
}
