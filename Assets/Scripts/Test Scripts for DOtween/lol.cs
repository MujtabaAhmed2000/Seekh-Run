using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class lol : MonoBehaviour
{

    public Transform Tomato;
    public float animDuration;
    public Ease animEase;
    public GameObject Skewer;


    // Start is called before the first frame update
    void Start()
    {
        Tomato.transform.parent = Skewer.transform;
        Tomato
        .DOMoveZ(16f, animDuration)
        .SetEase(animEase)
        .SetLoops(-1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Skewer)
        {
            Debug.LogError("hitting");
            //Tomato.transform.parent = Skewer.transform;
            //Tomato
            //.DOMoveZ(-2f, animDuration)
            //.SetEase(animEase)
            //.From(0f);
            ////.SetLoops(-1);
        }
    }

}
