using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovement : MonoBehaviour
{
    [SerializeField] Transform slider;

    bool stop = false;
    float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            slider.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            if(slider.position.x > 1.5)
            {
                stop = true;
            }
        }
    }

    public string getCookState()
    {
        stop = true;

        if (slider.position.x < -0.64)
        {
            return "Raw";
        }
        else if(slider.position.x < 0.6)
        {
            return "Cooked";
        }
        else if(slider.position.x < 1.5)
        {
            return "Smoke";
        }
        else
        {
            return "Burnt";
        }
    }

    public void setEnabled(bool value)
    {
        gameObject.SetActive(value);
    }

}
