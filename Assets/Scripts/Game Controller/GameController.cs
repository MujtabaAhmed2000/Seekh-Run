using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GameController : MonoBehaviour
{
    [SerializeField] SeekhInfo seekhInfo;
    enum listOfItems { Tomato, Beef };
    [SerializeField] List<listOfItems> itemsInLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkWin()
    {
        List<GameObject> itemsOnSeekh = seekhInfo.getItemsOnSeekh();

        for(int i = 0; i < itemsOnSeekh.Capacity; i++)
        {
            foreach (string name in Enum.GetValues(typeof(listOfItems)))
            {
                if (itemsOnSeekh[i].name.Contains(name))
                {
                    //CALL WIN CONDITION
                    return;
                }
            }
        }

        //CALL LOSE CONDITION
    }
}