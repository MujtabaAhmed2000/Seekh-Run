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
    public void attachToSkewer(float zOffset, Transform skewer)
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
        //Vector3 offset = new Vector3(0, 0, 2.5f);

        //transform.DOMove(skewer.position + offset, animDuration).SetEase(Ease.OutBounce);

        //TO MAKE SURE IT ALIGNS EXACTLY ONTO THE POISITION
        //Invoke("alignItem", animDuration + 0.1f);

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
            //float xPos = (balancedPosition.x + transform.position.x) / 2;
            ////zPos += skewer.position.z;

            ////Vector3 mid = (balancedPosition + transform.position) / 2;

            //Debug.Log("PASS:" + i);
            //Debug.Log("CURRENT POSITION" + transform.position);
            //Debug.Log("BALANCED POSITION" + balancedPosition);
            //Debug.Log("SKEWER POSITION: " + skewer.position);
            //Debug.Log("X:" + xPos);
            ////Debug.Log("TWEEN POSITION:" + mid);

            transform.DOMoveX(balancedPosition.x, animTime).SetEase(Ease.OutBounce);

            yield return new WaitForSeconds(animTime);
        }
        //TO MAKE SURE THAT THE ITEM ALIGNS
        alignItem();
    }
}
