using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FoodCollect : MonoBehaviour
{
    FoodInfo foodInfo;
    float animDuration = 0.01f; //WAS 0.25f

    [SerializeField] private AudioSource FoodPickUp;
    public AudioClip Pick;
    public AudioClip Drop;
    [HideInInspector]public ParticleSystem shatter;
    //public float animDurationV2;
    //public Ease AnimEase;
    //float sub = 5f;
    //int i = 1;


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
        GetComponent<Animation>().Stop();
        transform.DOScale(10f, 0.25f);
    
        //var main = shatter.gameObject.GetComponent<ParticleSystem>().main;
        //main.startColor = GetComponent<MeshRenderer>().material.color;
        shatter.Play();

        transform.SetParent(skewer);


        //transform
        //.DOMoveZ(skewer.position.z - zOffset, animDuration)
        //.SetEase(Ease.OutBounce);

        transform.DOMove(skewer.position, animDuration).SetEase(Ease.OutBounce);

        //TO MAKE SURE IT ALIGNS EXACTLY ONTO THE POISITION
        Invoke("alignItem", animDuration + 0.1f);

        //transform.localPosition = new Vector3(0, 0, 0);
        //transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    public void detachFromSkewer()
    {
        //adding particle effect and sound
        FoodPickUp.clip = Drop;
        FoodPickUp.PlayOneShot(FoodPickUp.clip);
        //var main = shatter.gameObject.GetComponent<ParticleSystem>().main;
        //main.startColor = GetComponent<MeshRenderer>().material.color;
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
