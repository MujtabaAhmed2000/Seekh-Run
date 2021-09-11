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
            seekhInfo.addItemOnSeekh(other.gameObject);

            FoodCollect foodCollect = other.gameObject.GetComponent<FoodCollect>();
            foodCollect.attachToSkewer(zPositionOnSeekh, transform);
            zPositionOnSeekh -= gapBetweenItems;
        }
        
        else if(other.gameObject.tag == "Wall")
        {
            seekhInfo.removeTopItemOnSeekh().SetActive(false);
        }
    }
}
