using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekhInfo : MonoBehaviour
{
    public static SeekhInfo seekhInfoInstance;
    [SerializeField] int numberOfItems;
    List<GameObject> itemPlacesOnSeekh;
    [SerializeField] List<GameObject> itemsOnSeekh;
    [SerializeField] Transform tipOfSeekh;
    [SerializeField] Transform baseOfSeekh;
    float length;

    // Start is called before the first frame update
    void Start()
    {
        itemsOnSeekh = new List<GameObject>();
        itemPlacesOnSeekh = new List<GameObject>(numberOfItems);
        length = tipOfSeekh.localPosition.z - baseOfSeekh.localPosition.z;
        //initializePlacesOnSeekh();
    }

    void initializePlacesOnSeekh()
    {
        float space = length / numberOfItems;
        for(int i = 0; i < numberOfItems; i++)
        {
            itemPlacesOnSeekh.Add(new GameObject("Position " + i));
            itemPlacesOnSeekh[i].transform.SetParent(transform);
            itemPlacesOnSeekh[i].transform.localPosition = new Vector3(0, 0, transform.position.z + (space * i));
        }
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
}
