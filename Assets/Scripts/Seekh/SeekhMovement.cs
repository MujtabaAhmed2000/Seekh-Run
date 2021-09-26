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
    bool isFinalAnimation = false;
    float finalAnimationTime = 2f;
    [SerializeField] Transform finalSkewerPlaceholder;
    [SerializeField] Transform mitten;
    [SerializeField] Transform skewer;
    [SerializeField] CameraFollow cameraFollow;
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

        //TOUCH INPUT FOR WHEN THE FINAL ANIMATION IS PLAYING
        //if (Input.touchCount > 0 && isFinalAnimation)
        //{
        //    touch = Input.GetTouch(0);

        //    if (touch.phase == TouchPhase.Ended)
        //    {
        //        StartCoroutine(finalRotate());
        //        isFinalAnimation = false;
        //    }
        //}
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
        cameraFollow.finalAnimationPosition();
        skewer.DORotate(new Vector3(0, -90f, 0), finalAnimationTime);
        transform.DOMove(finalSkewerPlaceholder.position, finalAnimationTime);
        mitten.DOLocalRotate(new Vector3(0, -90, 0), finalAnimationTime);
        Invoke("setIsFinalAnimationTrue", finalAnimationTime);
    }

    void setIsFinalAnimationTrue()
    {
        isFinalAnimation = true;
    }

    public IEnumerator finalRotate()
    {
        for(int i = 0; i < 360; i++)
        {
            skewer.Rotate(new Vector3(0, 0, -1));

            yield return new WaitForSeconds(0.01f);
        }
        isFinalAnimation = false;
    }

    public bool getIsFinalAnimation()
    {
        return isFinalAnimation;
    }
}
