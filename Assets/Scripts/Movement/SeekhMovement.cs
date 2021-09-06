using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekhMovement : MonoBehaviour
{
    float speed = 1;
    Touch touch;
    float widthOfLevel;
    float xRightBound;
    float touchPosX;
    float newPosX;

    // Start is called before the first frame update
    void Start()
    {
        //FOR TESTING PURPOSE USE 1440 OTHERWISE USE SCREEN.WIDTH
        xRightBound = 1440 / 2;
        //xRightBound = Screen.width / 2;

        //WIDTH OF LEVEL IS 4.8
        widthOfLevel = 4.8f;
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
                touchPosX = touch.position.x - xRightBound;
                newPosX = (touchPosX * widthOfLevel) / xRightBound;

                transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
            }
        }
    }
}