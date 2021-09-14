using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInfo : MonoBehaviour
{
    Rigidbody rigidbody;
    bool isPickedUp = false;
    bool isFlung = false;
    float speed;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPickedUp)
        {
            //ADD CODE FOR ANIMATION
        }
        else if (isPickedUp)
        {
            //ADD CODE FOR ANIMATION
        }
        else if (isFlung)
        {
            //ADD CODE FOR ANIMATION AND TIMER TO SET ACTIVE FALSE
        }
    }

    public void setIsPickedUp(bool value)
    {
        isPickedUp = value;
    }

    public void flingItemUp()
    {
        float randomX = Random.Range(-3, 3);
        isFlung = true;
        rigidbody.useGravity = true;
        rigidbody.AddForce(new Vector3(randomX, 5f, 0), ForceMode.Impulse);
    }
}
