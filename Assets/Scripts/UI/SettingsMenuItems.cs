using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuItems : MonoBehaviour
{

    [HideInInspector] public Image img;
    [HideInInspector] public Transform trans;


    public void Awake()
    {
        img = GetComponent<Image>();
        trans = transform;
    }
}
