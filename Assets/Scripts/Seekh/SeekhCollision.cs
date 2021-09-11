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

            other.gameObject.GetComponent<FoodCollect>().attachToSkewer(zPositionOnSeekh, transform);
            zPositionOnSeekh -= gapBetweenItems;
        }
        
        else if(other.gameObject.tag == "Wall")
        {
            GameObject item = seekhInfo.removeTopItemOnSeekh();
            item.GetComponent<FoodCollect>().detachFromSkewer();
            item.GetComponent<FoodInfo>().flingItemUp(); 

            zPositionOnSeekh += gapBetweenItems;
        }
    }
}
