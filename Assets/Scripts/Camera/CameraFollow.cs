using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour
{
    bool isFollowing = true;
    [SerializeField] Transform target;
    [SerializeField] Vector3 skewerOffset;
    [SerializeField] Vector3 finalAnimOffset;
    [SerializeField] Vector3 finalAnimeRotation;
    [SerializeField] Vector3 plateOffset;
    [SerializeField] Vector3 plateRotation;

    float finalAnimTime = 2f;
    float plateAnimTime = 1.5f;

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + skewerOffset.z);
        }
    }

    public void changeTarget(Transform targetTransform)
    {
        target = targetTransform;
    }

    public void finalAnimationPosition()
    {
        gameObject.GetComponent<Camera>().DOFieldOfView(75, finalAnimTime);
        isFollowing = false;
        transform.DOMoveX(0, finalAnimTime);
        transform.DOMoveY(target.position.y + finalAnimOffset.y, finalAnimTime);
        transform.DOMoveZ(target.position.z + finalAnimOffset.z, finalAnimTime);
        //transform.DOMove(target.position + finalAnimOffset, finalAnimTime);
        transform.DORotate(finalAnimeRotation, finalAnimTime);
    }

    public void platePosition()
    {
        gameObject.GetComponent<Camera>().DOFieldOfView(90, plateAnimTime);
        transform.DOMoveX(0, plateAnimTime);
        transform.DOMoveY(target.position.y + plateOffset.y, plateAnimTime);
        transform.DOMoveZ(target.position.z + plateOffset.z, plateAnimTime);
        //transform.DOMove(target.position + plateOffset, plateAnimTime);
        transform.DORotate(plateRotation, plateAnimTime);
    }
}
