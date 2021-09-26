using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovement : MonoBehaviour
{
    [SerializeField] Transform slider;

    bool stop = false;
    float speed = 2f;
    float leftBound = -1.754f;
    float rightBound = 1.754f;

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            if(slider.position.x > rightBound || slider.position.x < leftBound)
            {
                speed *= -1;
            }
            slider.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }

    public string getCookState()
    {
        stop = true;

        if (slider.position.x < -1.4 || slider.position.x > 1.4)
        {
            return "Burnt";
        }
        else if(slider.position.x < -0.47 || slider.position.x > 0.47)
        {
            return "Raw";
        }
        else
        {
            return "Cooked";
        }
    }

    public void setEnabled(bool value)
    {
        gameObject.SetActive(value);
    }

}
