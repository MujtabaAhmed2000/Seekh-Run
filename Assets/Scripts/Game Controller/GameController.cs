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
    Touch touch;
    bool sliderIsMoving = false;
    bool sliderMovementFlag = true;

    // CAN BE "Burnt" "Raw" "Cooked" "Smoke"
    String stateOfFood = null;

    enum listOfItems { Tomato, Beef };
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
                Debug.Log(stateOfFood);
                StartCoroutine(seekhMovement.finalRotate());
                Invoke("hideSlider", 1f);
            }
        }
 
    }

    public void checkWin()
    {
        List<GameObject> itemsOnSeekh = seekhInfo.getItemsOnSeekh();

        for(int i = 0; i < itemsOnSeekh.Capacity; i++)
        {
            foreach (string name in Enum.GetValues(typeof(listOfItems)))
            {
                if (itemsOnSeekh[i].name.Contains(name))
                {
                    //CALL WIN CONDITION
                    return;
                }
            }
        }

        //CALL LOSE CONDITION
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
    } 
}
