using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0, 60f, -50f);

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }

    public void changeTarget(Transform targetTransform)
    {
        target = targetTransform;
    }


}
