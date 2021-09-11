using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekhCollision : MonoBehaviour
{
    [SerializeField] SeekhInfo seekhInfo;
    float zPositionOnSeekh = 5f;
    float gapBetweenItems = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Food")
        {
            FoodCollect foodCollect = other.gameObject.GetComponent<FoodCollect>();
            foodCollect.attachToSkewer(zPositionOnSeekh, transform);
            zPositionOnSeekh -= gapBetweenItems;
        }
    }
}
