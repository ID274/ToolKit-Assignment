using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    private bool pickingUp = false;

    private void Start()
    {
        item.count = 0;
    }

    public void Pickup()
    {
        item.count++;
        if (item.count <= 1)
        {
            InventoryManager.Instance.Add(item);
            InventoryManager.Instance.ListItems();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
            InventoryManager.Instance.ListItems();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!pickingUp)
        {
            pickingUp = true;
            Pickup();
        }
    }
}
