using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekhInfo : MonoBehaviour
{
    public static SeekhInfo seekhInfoInstance;
    [SerializeField] List<GameObject> itemsOnSeekh;

    // Start is called before the first frame update
    void Start()
    {
        itemsOnSeekh = new List<GameObject>();
    }

    public void addItemOnSeekh(GameObject item)
    {
        itemsOnSeekh.Add(item);
    }

    public void RemoveItemOnSeekh(GameObject item)
    {
        itemsOnSeekh.Remove(item);
    }

    public int getNumberOfItemsOnSeekh()
    {
        return itemsOnSeekh.Count;
    }

    public GameObject removeTopItemOnSeekh()
    {
        GameObject temp = itemsOnSeekh[itemsOnSeekh.Count - 1];
        itemsOnSeekh.RemoveAt(itemsOnSeekh.Count - 1);
        return temp;
    }

}
