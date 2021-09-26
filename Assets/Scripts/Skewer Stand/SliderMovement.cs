using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovement : MonoBehaviour
{
    [SerializeField] Transform slider;

    bool stop = false;
    float speed = 2.5f;

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            slider.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            if(slider.position.x > 3.6)
            {
                stop = true;
            }
        }
    }

    public string getCookState()
    {
        stop = true;

        if (slider.position.x < -1.4)
        {
            return "Raw";
        }
        else if(slider.position.x < 1.49)
        {
            return "Cooked";
        }
        else if(slider.position.x < 3.5)
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
