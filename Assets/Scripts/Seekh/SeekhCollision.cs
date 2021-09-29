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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Food")
        {
            int position = seekhInfo.getNumberOfItemsOnSeekh();

            if(position == 10)
            {
                return;
            }

            other.gameObject.GetComponent<FoodInfo>().disableCollider();

            seekhInfo.addItemOnSeekh(other.gameObject);

            other.gameObject.GetComponent<FoodCollect>().attachToSkewer(itemPositions[position].transform);
        }
        
        else if(other.gameObject.tag == "Wall")
        {
            shakeSeekh();

            if(seekhInfo.getNumberOfItemsOnSeekh() == 0)
            {
                return;
            }

            GameObject item = seekhInfo.removeTopItemOnSeekh();
            item.GetComponent<FoodCollect>().detachFromSkewer();
            item.GetComponent<FoodInfo>().flingItemUp();
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
