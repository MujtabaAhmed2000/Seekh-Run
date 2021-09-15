using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDelete : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            transform.gameObject.SetActive(false);
        }
    }
}
