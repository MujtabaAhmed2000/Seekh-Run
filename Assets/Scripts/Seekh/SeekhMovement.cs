using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SeekhMovement : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] CameraFollow cameraFollow;
    [SerializeField] Transform finalSkewerPlaceholder;
    [SerializeField] float speed;

    Touch touch;
    float rightLevelBoundary;
    float sensitivity = 25;
    bool isControl = false;
    bool isFinalAnimation = false;
    bool isUiSlider = true;
    float finalAnimationTime = 2f;
    [SerializeField] Transform mitten;
    [SerializeField] Transform skewer;


    // Start is called before the first frame update
    void Start()
    {
        //WIDTH OF LEVEL IS 4.8
        rightLevelBoundary = 4.8f;
    }

    // Update is called once per frame
    void Update()
    {
        //DETECTING FIRST TOUCH AND DISABLING THE UI SLIDER AND START THE LEVEL
        if(Input.touchCount > 0 && isUiSlider)
        {
            isUiSlider = false;
            isControl = true;
            gameController.hideStartScreen();
        }

        //TO MAKE SEEKH MOVE FORWARD
        if (isControl)
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }

        //TO MAKE SEEKH MOVE LEFT RIGHT
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
        for(int i = 0; i < 180; i++)
        {
            skewer.Rotate(new Vector3(0, 0, -2));

            yield return new WaitForSeconds(0.005f);
        }
        isFinalAnimation = false;

        moveToPlate();
    }

    public bool getIsFinalAnimation()
    {
        return isFinalAnimation;
    }

    void moveToPlate()
    {
        mitten.gameObject.SetActive(false);
        cameraFollow.platePosition();
        Vector3 offset = new Vector3(0, -1f, 15);
        transform.DOMove(transform.position + offset, 1.5f);

    }
}
