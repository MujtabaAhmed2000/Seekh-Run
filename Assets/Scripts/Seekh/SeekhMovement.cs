using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SeekhMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Touch touch;
    float rightLevelBoundary;
    float sensitivity = 25;
    bool isControl = true;
    [SerializeField] Transform skewerStand;
    //float xRightBound;

    // Start is called before the first frame update
    void Start()
    {
        //FOR TESTING PURPOSE USE 1440 OTHERWISE USE SCREEN.WIDTH
        //xRightBound = Screen.width / 2;

        //WIDTH OF LEVEL IS 4.8
        rightLevelBoundary = 4.8f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isControl)
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }

        if(Input.touchCount > 0 && isControl)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                float moveX = (touch.deltaPosition.x / Screen.width) * sensitivity;
                float newPos = moveX * Time.deltaTime * 10;

                if (transform.position.x + newPos < rightLevelBoundary && transform.position.x + newPos > -rightLevelBoundary)
                {
                    transform.Translate(new Vector3(newPos, 0, 0));
                }
            }
        }
    }

    public void shakeSeekh()
    {
        transform.DOShakePosition(1f);
    }

    public void setIsControl(bool value)
    {
        isControl = value;
    }

    public void finalAnimation()
    {
        transform.DORotate(new Vector3(0, -90, 0), 2f);
        transform.DOMove(skewerStand.position, 2f);
    }
}
