using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekhMovement : MonoBehaviour
{
    float speed = 1;
    Touch touch;
    float xRightBound;
    float newPosX;

    // Start is called before the first frame update
    void Start()
    {
        xRightBound = Screen.width / 2;
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
                newPosX = touch.position.x - xRightBound;

                Debug.Log(newPosX);

                //transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
            }
        }
    }
}
