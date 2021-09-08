using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekhInfo : MonoBehaviour
{
    [SerializeField] int numberOfItems;
    List<GameObject> itemsOnSeekh;
    

    // Start is called before the first frame update
    void Start()
    {
        itemsOnSeekh = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
