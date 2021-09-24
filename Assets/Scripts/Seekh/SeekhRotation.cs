using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SeekhRotation : MonoBehaviour
{
    Touch touch;
    float maxRightAngle = 30;
    float touchMargin = 10;
    bool isControl = true;
    bool isFinalAnimation = false;
    float finalAnimationTime = 2f;
    int spins = 5;
    int spinCount = 0;
    float spinTime = 1.5f;
    [SerializeField] Transform finalSkewerPlaceholder;

    //THIS IS THE HIGHEST DELTA I COULD GET BY SWIMPING THE SCREEN REALLY FAST. THIS VALUE CORRESPONDS TO THE touch.deltaPosition
    float maxDelta = 100;

    void Update()
    {
        if (isControl)
        {
            rotateReset();
        }

        if(Input.touchCount > 0 && isControl)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                //Debug.Log(touch.deltaPosition);

                //IF DELTA POSITION IS MAX DELTA, ROTATE IT TO MAX ANGLE, THE RATIO OF ROTATION IS DETERMINED BY THE DELTA POSITION
                if(touch.deltaPosition.x < -touchMargin)
                {
                    float angle = (-maxRightAngle * touch.deltaPosition.x) / -maxDelta;
                    rotateLeft(angle);
                }
                else if(touch.deltaPosition.x > touchMargin)
                {
                    float angle = (maxRightAngle * touch.deltaPosition.x) / maxDelta;
                    rotateRight(angle);
                }
                else
                {
                    rotateReset();
                }

            }
        }

        //TOUCH INPUT FOR WHEN THE FINAL ANIMATION IS PLAYING
        if (Input.touchCount > 0 && isFinalAnimation)
        {
            touch = Input.GetTouch(0);
            spinCount++;
            finalRotate();
            if(spinCount == spins)
            {
                isFinalAnimation = false;
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
        transform.DORotate(new Vector3(0, 0, 0), 0.25f);
    }

    public void setIsControl(bool value)
    {
        isControl = value;
    }

    public void finalAnimation()
    {
        transform.DORotate(new Vector3(0, -90, 0), finalAnimationTime);
        transform.DOMove(finalSkewerPlaceholder.position, finalAnimationTime);
        Invoke("setIsFinalAnimationTrue", finalAnimationTime);
    }

    void setIsFinalAnimationTrue()
    {
        isFinalAnimation = true;
    }

    void finalRotate()
    {
        transform.DORotate(new Vector3(360, 0, 0), spinTime);
    }
}
