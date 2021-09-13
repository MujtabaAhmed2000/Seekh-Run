using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FoodCollect : MonoBehaviour
{
    FoodInfo foodInfo;
    public float animDuration = 0.25f;

    [SerializeField] private AudioSource FoodPickUp;
    public AudioClip Pick;
    public AudioClip Drop;
    public ParticleSystem shatter;
    //public float animDurationV2;
    //public Ease AnimEase;
    //float sub = 5f;
    //int i = 1;


    private void Start()
    {
        foodInfo = GetComponent<FoodInfo>();
    }
    public void attachToSkewer(float zOffset, Transform skewer)
    {
        foodInfo.setIsPickedUp(true);

        transform.SetParent(skewer);

        transform
        .DOMoveZ(transform.position.z - zOffset, animDuration)
        .SetEase(Ease.OutBounce);

        //adding particle effect and sound
        FoodPickUp.clip = Pick;
        FoodPickUp.PlayOneShot(FoodPickUp.clip);

        var main = shatter.gameObject.GetComponent<ParticleSystem>().main;
        main.startColor = GetComponent<MeshRenderer>().material.color;
        shatter.Play();

        transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
    }

    public void detachFromSkewer()
    {
        //adding particle effect and sound
        FoodPickUp.clip = Drop;
        FoodPickUp.PlayOneShot(FoodPickUp.clip);
        //var main = shatter.gameObject.GetComponent<ParticleSystem>().main;
        //main.startColor = GetComponent<MeshRenderer>().material.color;
        //shatter.Play();
        foodInfo.setIsPickedUp(false);
        transform.SetParent(null);
    }

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

    //private void OnTriggerEnter(Collider other)
    //{
        /*if (other.gameObject.tag == "Player")
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
        }*/


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
    //}

}
