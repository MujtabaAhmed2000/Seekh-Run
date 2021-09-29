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
    [HideInInspector] public ParticleSystem shatter;

    private void Start()
    {
        foodInfo = GetComponent<FoodInfo>();
        shatter = GetComponent<ParticleSystem>();
        FoodPickUp = GetComponent<AudioSource>();

    }
    public void attachToSkewer(Transform skewer)
    {
        //VIBRATION
        Handheld.Vibrate();

        foodInfo.setIsPickedUp(true);
        transform.SetParent(skewer);

        //adding particle effect and sound
        FoodPickUp.clip = Pick;
        FoodPickUp.PlayOneShot(FoodPickUp.clip);

        shatter.Play();
        
        //MOVE THE ITEM
        StartCoroutine(moveItem(skewer));

        transform.DOShakeScale(1f);
    }

    public void detachFromSkewer()
    {
        //VIBRATION
        Handheld.Vibrate();

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

    IEnumerator moveItem(Transform skewer)
    {
        Vector3 offset = new Vector3(0, 0, 2.5f);
        Vector3 balancedPosition = skewer.position + offset;

        transform.DOMoveZ(balancedPosition.z, animDuration).SetEase(Ease.OutBounce);

        //TO MOVE ITEM X AXIS TO MAKE IT SMOOTHER
        int frequency = 4;
        float animTime = animDuration / frequency;
        for(int i = 0; i < frequency; i++)
        {
            transform.DOMoveX(balancedPosition.x, animTime).SetEase(Ease.OutBounce);

            yield return new WaitForSeconds(animTime);
        }
        //TO MAKE SURE THAT THE ITEM ALIGNS
        alignItem();
    }
}
