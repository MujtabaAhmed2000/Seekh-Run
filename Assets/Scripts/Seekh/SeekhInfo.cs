using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekhInfo : MonoBehaviour
{
    [SerializeField] int numberOfItems;
    float length = 1.73f;
    List<GameObject> itemPlacesOnSeekh;
    List<GameObject> itemsOnSeekh;
    [SerializeField] Transform tipOfSeekh;
    [SerializeField] Transform baseOfSeekh;

    // Start is called before the first frame update
    void Start()
    {
        itemsOnSeekh = new List<GameObject>();
        itemPlacesOnSeekh = new List<GameObject>(numberOfItems);
        /*GameObject gameObject = new GameObject("POSITION 1");
        gameObject.transform.SetParent(transform);
        gameObject.transform.Translate(new Vector3(0, 0, 2));
        GameObject gameObject2 = new GameObject("POSITION 2");
        GameObject gameObject3 = new GameObject("POSITION 3");*/
        initializePlacesOnSeekh();
    }

    void initializePlacesOnSeekh()
    {
        //Debug.Log(itemPlacesOnSeekh.Capacity);

        float space = length / numberOfItems;
        for(int i = 0; i < numberOfItems; i++)
        {
            itemPlacesOnSeekh.Add(new GameObject("Position " + i));
            //itemPlacesOnSeekh[i] = new GameObject("Position " + i);
            itemPlacesOnSeekh[i].transform.SetParent(transform);
            //itemPlacesOnSeekh[i].transform.Translate(new Vector3(0, 0, space * i), Space.Self);
            itemPlacesOnSeekh[i].transform.localPosition = new Vector3(0, 0, transform.position.z + (space * i));
        }


        /*itemPlacesOnSeekh[0] = new GameObject("Position " + 0);
        itemPlacesOnSeekh[0].transform.SetParent(transform);
        itemPlacesOnSeekh[0].transform.Translate(new Vector3(0, 0, space * 0));

        itemPlacesOnSeekh[1] = new GameObject("Position " + 1);
        itemPlacesOnSeekh[1].transform.SetParent(transform);
        itemPlacesOnSeekh[1].transform.Translate(new Vector3(0, 0, space * 1));

        itemPlacesOnSeekh[2] = new GameObject("Position " + 2);
        itemPlacesOnSeekh[2].transform.SetParent(transform);
        itemPlacesOnSeekh[2].transform.Translate(new Vector3(0, 0, space * 2));*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
