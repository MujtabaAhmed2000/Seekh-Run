using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public GameObject Slider;
    public GameObject Hand;

    public void StartButton()
    {
        Slider.SetActive(false);
        Hand.SetActive(false);
    }
}
