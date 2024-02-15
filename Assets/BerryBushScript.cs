using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryBushScript : MonoBehaviour
{
    [SerializeField] private PlantScript plantScript;

    public Item item;


    private void OnTriggerEnter(Collider other)
    {
        InventoryManager.Instance.Add(item);
        item.count++;
        Destroy(gameObject);
    }
}
