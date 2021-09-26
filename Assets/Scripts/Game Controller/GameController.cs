using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GameController : MonoBehaviour
{
    [SerializeField] SeekhInfo seekhInfo;
    [SerializeField] SeekhMovement seekhMovement;
    [SerializeField] SliderMovement sliderMovement;
    [SerializeField] CameraFollow cameraFollow;

    [SerializeField] Transform neutralEmoji;
    [SerializeField] Transform sadEmoji;
    [SerializeField] Transform happyEmoji;
    [SerializeField] Transform sickEmoji;

    Touch touch;
    bool sliderIsMoving = false;
    bool sliderMovementFlag = true;

    // CAN BE "Burnt" "Raw" "Cooked" "Smoke"
    String stateOfFood = null;

    enum listOfItems { Cheese, Chicken, Donut, EclairChocolate, Muffin, Mushroom, Onion, Pepper, Pineapple, Salad, Sausage, Shrimp, SweetPepper, Tomato };
    [SerializeField] List<listOfItems> itemsInLevel;

    // Update is called once per frame
    void Update()
    {
        if (seekhMovement.getIsFinalAnimation() && sliderMovementFlag)
        {
            sliderMovementFlag = false;
            sliderMovement.setEnabled(true);
            sliderIsMoving = true;
            Invoke("sliderTimer", 3f);
        }

        if (Input.touchCount > 0 && sliderIsMoving)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                CancelInvoke();
                sliderIsMoving = false;
                stateOfFood = sliderMovement.getCookState();
                StartCoroutine(seekhMovement.finalRotate());
                Invoke("hideSlider", 1f);
            }
        }
 
    }

    //IS BEING CALLED FROM HIDESLIDER FUNCTION
    public void checkWin()
    {
        List<GameObject> itemsOnSeekh = seekhInfo.getItemsOnSeekh();

        if(itemsOnSeekh.Capacity == 0)
        {
            showSad();
            return;
        }

        for(int i = 0; i < itemsOnSeekh.Capacity; i++)
        {
            foreach (string name in Enum.GetValues(typeof(listOfItems)))
            {
                if (itemsOnSeekh[i].name.Contains(name))
                {
                    if (stateOfFood.Equals("Cooked"))
                    {
                        showHappy();
                    }
                    else if (stateOfFood.Equals("Raw"))
                    {
                        showSick();
                    }
                    else if (stateOfFood.Equals("Smoke"))
                    {
                        showHappy();
                    }
                    else if (stateOfFood.Equals("Burnt"))
                    {
                        showSick();
                    }
                    return;
                }
            }
        }

        showSad();
    }

    void sliderTimer()
    {
        sliderIsMoving = false;
        StartCoroutine(seekhMovement.finalRotate());
        stateOfFood = "Burnt";
        Invoke("hideSlider", 1f);
    }

    void hideSlider()
    {
        sliderMovement.setEnabled(false);
        Invoke("checkWin", 2f);
    } 

    void showHappy()
    {
        neutralEmoji.gameObject.SetActive(false);
        happyEmoji.gameObject.SetActive(true);
    }

    void showSad()
    {
        neutralEmoji.gameObject.SetActive(false);
        sadEmoji.gameObject.SetActive(true);
    }

    void showSick()
    {
        neutralEmoji.gameObject.SetActive(false);
        sickEmoji.gameObject.SetActive(true);
    }
}
