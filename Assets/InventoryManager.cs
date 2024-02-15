using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> items = new List<Item>();

    [Header("References")]
    [SerializeField] private GameObject[] itemSlots;
    [SerializeField] private TextMeshProUGUI[] itemCounts;
    public Color emptyColor = Color.gray;

    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemCounts[i].text = 0.ToString();
            itemSlots[i].GetComponent<Image>().color = emptyColor;
        }
    }

    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }
}
