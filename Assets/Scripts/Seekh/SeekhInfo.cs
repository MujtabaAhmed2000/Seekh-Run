using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekhInfo : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] List<GameObject> itemsOnSeekh;

    [Header("PARTICLE EFFECTS FOR COOKED STATE")]
    [SerializeField] GameObject cooked;
    [SerializeField] GameObject smoke;
    [SerializeField] GameObject burnt;
    [SerializeField] GameObject raw;

    void Start()
    {
        itemsOnSeekh = new List<GameObject>();
    }

    public void addItemOnSeekh(GameObject item)
    {
        itemsOnSeekh.Add(item);
        gameController.checkIfItemAddedIsRequired(item);
    }

    public void RemoveItemOnSeekh(GameObject item)
    {
        itemsOnSeekh.Remove(item);
        gameController.checkIfItemRemovedIsRequired(item);
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

    public List<GameObject> getItemsOnSeekh()
    {
        return itemsOnSeekh;
    }

    public void enableEndingParticleEffect(string state)
    {
        if (state.Equals("Cooked"))
        {
            cooked.SetActive(true);
        }
        else if (state.Equals("Raw"))
        {
            raw.SetActive(true);
        }
        else if (state.Equals("Smoke"))
        {
            smoke.SetActive(true);
        }
        else if (state.Equals("Burnt"))
        {
            burnt.SetActive(true);
        }
    }
}
