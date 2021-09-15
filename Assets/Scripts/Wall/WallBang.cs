using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBang : MonoBehaviour
{
    //[HideInInspector] public ParticleSystem shatter;
    private void Start()
    {
        //shatter = GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //transform.GetChild(0)
            //shatter.Play();
        }
    }
}
