using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

            other.gameObject.GetComponent<FoodCollect>().attachToSkewer(zPositionOnSeekh, itemPositions[position].transform);

            zPositionOnSeekh -= gapBetweenItems;
        }
        
        else if(other.gameObject.tag == "Wall")
        {
            shakeSeekh();

            GameObject item = seekhInfo.removeTopItemOnSeekh();
            item.GetComponent<FoodCollect>().detachFromSkewer();
            item.GetComponent<FoodInfo>().flingItemUp();

            zPositionOnSeekh += gapBetweenItems;
        }

        else if(other.gameObject.tag == "Finish")
        {
            seekhMovement.setIsControl(false);
            seekhRotation.setIsControl(false);
            seekhMovement.finalAnimation();
        }
    }

    void shakeSeekh()
    {
        transform.DOShakePosition(0.3f, strength: 0.5f);
    }
}
