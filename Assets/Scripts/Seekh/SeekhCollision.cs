using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekhCollision : MonoBehaviour
{
    [SerializeField] SeekhInfo seekhInfo;
    [SerializeField] List<GameObject> itemPositions;
    float zPositionOnSeekh = 3f;
    float gapBetweenItems = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Food")
        {
            int position = seekhInfo.getNumberOfItemsOnSeekh();

            seekhInfo.addItemOnSeekh(other.gameObject);

            //other.gameObject.GetComponent<FoodCollect>().attachToSkewer(zPositionOnSeekh, transform);
            other.gameObject.GetComponent<FoodCollect>().attachToSkewer(zPositionOnSeekh, itemPositions[position].transform);

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

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Stove")
        {
            //Debug.Log("INSIDE STOVE");
        }
    }
}
