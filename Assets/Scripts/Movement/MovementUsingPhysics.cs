using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementUsingPhysics : MonoBehaviour
{

    float widthOfLevel;
    float xRightBound;
    Touch touch;
    float touchPosX;
    float newPosX;
    public float speed = 10f;
    public Rigidbody rb;
    public Vector3 movement;

    void Start()
    {
        xRightBound = Screen.width / 2;
        widthOfLevel = 4.8f;
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                touchPosX = touch.position.x - xRightBound;
                newPosX = (touchPosX * widthOfLevel) / xRightBound;

                movement = new Vector3(newPosX, transform.position.y, transform.position.z);
            }
        }
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));

    }
}
