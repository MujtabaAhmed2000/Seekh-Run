using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EmojiMovement : MonoBehaviour
{
    [SerializeField] Transform emoji;
    float distance = 2f;
    float time = 1f;

    void Start()
    {
        moveUp();
    }

    void moveUp()
    {
        emoji.DOMoveY(emoji.position.y + distance, time);
        Invoke("moveDown", time);
    }

    void moveDown()
    {
        emoji.DOMoveY(emoji.position.y - distance, time);
        Invoke("moveUp", time);
    }
}
