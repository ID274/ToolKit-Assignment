using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> items = new List<Item>();

    public Transform itemContent;
    public GameObject inventoryItem;




    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {

    }

    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemIcon = obj.transform.Find("itemIcon").GetComponent<Image>();
            var itemCount = obj.transform.Find("itemCount").GetComponent<TMP_Text>();

            itemIcon.sprite = item.itemSprite;
            itemCount.text = item.count.ToString();
        }
    }
}
