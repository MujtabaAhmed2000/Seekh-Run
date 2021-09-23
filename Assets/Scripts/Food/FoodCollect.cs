using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FoodCollect : MonoBehaviour
{
    FoodInfo foodInfo;
    float animDuration = 0.15f; //WAS 0.25f

    [HideInInspector] private AudioSource FoodPickUp;
    public AudioClip Pick;
    public AudioClip Drop;
    [HideInInspector]public ParticleSystem shatter;

    private void Start()
    {
        foodInfo = GetComponent<FoodInfo>();
        shatter = GetComponent<ParticleSystem>();
        FoodPickUp = GetComponent<AudioSource>();
        
    }
    public void attachToSkewer(float zOffset, Transform skewer)
    {
        foodInfo.setIsPickedUp(true);

        //adding particle effect and sound
        FoodPickUp.clip = Pick;
        FoodPickUp.PlayOneShot(FoodPickUp.clip);

        shatter.Play();
        transform.SetParent(skewer);

        Vector3 offset = new Vector3(0, 0, 2.5f);

        transform.DOMove(skewer.position + offset , animDuration).SetEase(Ease.OutBounce);

        //TO MAKE SURE IT ALIGNS EXACTLY ONTO THE POISITION
        Invoke("alignItem", animDuration + 0.1f);
        
        transform.DOShakeScale(1f);
    }

    public void detachFromSkewer()
    {
        //adding particle effect and sound
        FoodPickUp.clip = Drop;
        FoodPickUp.PlayOneShot(FoodPickUp.clip);
        shatter.Play();
        
        foodInfo.setIsPickedUp(false);
        transform.SetParent(null);
    }

    void alignItem()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        transform.localEulerAngles = new Vector3(0, 0, 0);
    }
}
