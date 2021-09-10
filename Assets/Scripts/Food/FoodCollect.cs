using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FoodCollect : MonoBehaviour
{
    float animDuration = 0.5f;
    public float animDurationV2;
    public Ease AnimEase;
    float sub = 5f;
    int i = 1;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        SeekhInfo seekhInfo = other.gameObject.GetComponent<SeekhInfo>();
    //        seekhInfo.addItemOnSeekh(gameObject);

    //        transform.SetParent(other.gameObject.transform);

    //        Debug.Log(seekhInfo.getNumberOfItemsOnSeekh());

    //        if (seekhInfo.getNumberOfItemsOnSeekh() == 1)
    //        {
    //            transform
    //            .DOMoveZ(transform.position.z - 5f, animDuration)
    //            .SetEase(Ease.OutBounce);
    //        }
    //        else if (seekhInfo.getNumberOfItemsOnSeekh() == 2)
    //        {
    //            transform
    //            .DOMoveZ(transform.position.z - 4f, animDuration)
    //            .SetEase(Ease.OutBounce);
    //        }
    //        else if (seekhInfo.getNumberOfItemsOnSeekh() == 3)
    //        {
    //            transform
    //            .DOMoveZ(transform.position.z - 3f, animDuration)
    //            .SetEase(Ease.OutBounce);
    //        }
    //        else if (seekhInfo.getNumberOfItemsOnSeekh() == 4)
    //        {
    //            transform
    //            .DOMoveZ(transform.position.z - 2f, animDuration)
    //            .SetEase(Ease.OutBounce);
    //        }
    //    }


    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SeekhInfo seekhInfo = other.gameObject.GetComponent<SeekhInfo>();
            seekhInfo.addItemOnSeekh(gameObject);

            transform.SetParent(other.gameObject.transform);

            while (sub >= 2f)
            { 
                if (seekhInfo.getNumberOfItemsOnSeekh() == i)
                {
                    transform
                    .DOMoveZ(transform.position.z - sub, animDuration)
                    .SetEase(Ease.OutBounce);

                    transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
                }
                sub--;
                i++;
            }
        }
        //if(other.gameObject.tag == "ouch")
        //{
        //    SeekhInfo seekhInfo = other.gameObject.GetComponent<SeekhInfo>();
        //    seekhInfo.RemoveItemOnSeekh(gameObject);

        //    //should we destroy the object that was removed???

        //    Debug.Log(seekhInfo.getNumberOfItemsOnSeekh());
        //    transform
        //        .DOMoveY(transform.position.y + 10f, animDurationV2)
        //        .SetEase(AnimEase);
        //    sub++;
        //    i--;
        //}
    }

}
