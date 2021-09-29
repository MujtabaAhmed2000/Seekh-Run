using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovement : MonoBehaviour
{
    [SerializeField] GameObject sliderObject;
    [SerializeField] RectTransform slider;

    bool stop = false;
    float speed = 5f;

    void Update()
    {
        if (!stop)
        {
            slider.Translate(new Vector3(speed, 0, 0));
            if(slider.anchoredPosition.x > 350)
            {
                speed *= -1;
            }
            if(slider.anchoredPosition.x < -350)
            {
                speed *= -1;
            }
        }
    }

    public string getCookState()
    {
        stop = true;

        if(slider.anchoredPosition.x < -265 || slider.anchoredPosition.x > 265)
        {
            return "Burnt";
        }
        else if(slider.anchoredPosition.x < -75 || slider.anchoredPosition.x > 110)
        {
            return "Smoke";
        }
        else
        {
            return "Cooked";
        }
    }

    public void setEnabled(bool value)
    {
        sliderObject.SetActive(value);
    }

}
