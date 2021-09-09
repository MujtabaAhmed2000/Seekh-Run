using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FoodCollect : MonoBehaviour
{
    float animDuration = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SeekhInfo seekhInfo = other.gameObject.GetComponent<SeekhInfo>();
            seekhInfo.addItemOnSeekh(gameObject);

            transform.SetParent(other.gameObject.transform);

            Debug.Log(seekhInfo.getNumberOfItemsOnSeekh());

            if (seekhInfo.getNumberOfItemsOnSeekh() == 1)
            {
                transform
                .DOMoveZ(transform.position.z - 5f, animDuration)
                .SetEase(Ease.OutBounce);
            }
            else if (seekhInfo.getNumberOfItemsOnSeekh() == 2)
            {
                transform
                .DOMoveZ(transform.position.z - 4f, animDuration)
                .SetEase(Ease.OutBounce);
            }
            else if (seekhInfo.getNumberOfItemsOnSeekh() == 3)
            {
                transform
                .DOMoveZ(transform.position.z - 3f, animDuration)
                .SetEase(Ease.OutBounce);
            }
            else if (seekhInfo.getNumberOfItemsOnSeekh() == 4)
            {
                transform
                .DOMoveZ(transform.position.z - 2f, animDuration)
                .SetEase(Ease.OutBounce);
            }
        }
    }

}
