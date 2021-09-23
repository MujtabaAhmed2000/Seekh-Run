using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekhCollision : MonoBehaviour
{
    [SerializeField] SeekhInfo seekhInfo;
    [SerializeField] List<GameObject> itemPositions;
    [SerializeField] SeekhMovement seekhMovement;
    [SerializeField] SeekhRotation seekhRotation;
    float zPositionOnSeekh = 3f;
    float gapBetweenItems = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Food")
        {
            int position = seekhInfo.getNumberOfItemsOnSeekh();

            other.gameObject.GetComponent<FoodInfo>().disableCollider();

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

            //seekhMovement.shakeSeekh();

            zPositionOnSeekh += gapBetweenItems;
        }

        else if(other.gameObject.tag == "Finish")
        {
            Debug.Log("FINISHED");
            seekhMovement.setIsControl(false);
            seekhRotation.setIsControl(false);
            seekhMovement.finalAnimation();
        }
    }
}
