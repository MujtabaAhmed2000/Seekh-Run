using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSliderCollision : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
    }
}
