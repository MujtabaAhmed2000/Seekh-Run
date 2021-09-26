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
        gameObject.GetComponent<Camera>().DOFieldOfView(75, 2f);
        isFollowing = false;
        transform.DOMove(target.position + finalAnimOffset, 2f);
        transform.DORotate(finalAnimeRotation, 2f);
    }
}
