using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public GameObject DestroyedWall;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(DestroyedWall, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
