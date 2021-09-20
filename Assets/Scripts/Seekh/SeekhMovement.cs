using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekhMovement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    Touch touch;
    float rightLevelBoundary;
    float sensitivity = 25;
    float xRightBound;
    float touchPosX;
    //float newPosX;

    // Start is called before the first frame update
    void Start()
    {
        //FOR TESTING PURPOSE USE 1440 OTHERWISE USE SCREEN.WIDTH
        //xRightBound = 1440 / 2;
        xRightBound = Screen.width / 2;

        //WIDTH OF LEVEL IS 4.8
        rightLevelBoundary = 4.8f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));

        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                //touchPosX = touch.position.x - xRightBound;
                //newPosX = (touchPosX * widthOfLevel) / xRightBound;

                //transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);

                //float moveX = (touch.deltaPosition.x % widthOfLevel) / (Screen.width / 4);

                float moveX = (touch.deltaPosition.x / Screen.width) * sensitivity;
                float newPos = moveX * Time.deltaTime * 10;

                if (transform.position.x + newPos < rightLevelBoundary && transform.position.x + newPos > -rightLevelBoundary)
                {
                    transform.Translate(new Vector3(newPos, 0, 0));
                }
                else
                {
                    Debug.Log("NO MOVEMENT");
                }

                //transform.Translate(new Vector3(newPos, 0, 0));

                //Debug.Log(transform.position.x);
            }
        }
    }
}
