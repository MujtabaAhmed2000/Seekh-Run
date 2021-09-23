using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FoodInfo : MonoBehaviour
{
    Rigidbody rigidbody;
    bool isPickedUp = false;
    bool isFlung = false;
    float scaleDuration = 0.5f;
    float scaleIncrease = 3f;
    float currentScale;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        currentScale = transform.localScale.x;
        makeBig();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickedUp)
        {
            CancelInvoke();
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

    void makeBig()
    {
        transform.DOScale(currentScale + scaleIncrease, scaleDuration);
        Invoke("makeSmall", scaleDuration);
    }

    void makeSmall()
    {
        transform.DOScale(currentScale, scaleDuration);
        Invoke("makeBig", scaleDuration);
    }
}
