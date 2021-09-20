using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        //transform.position = target.position + offset;
        transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + offset.z);
    }

    public void changeTarget(Transform targetTransform)
    {
        target = targetTransform;
    }
}
