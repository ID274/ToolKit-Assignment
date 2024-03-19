using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item" ,menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    [Header("Attrributes")]
    public int itemID;
    public string itemName;
    public Sprite itemSprite;

    [HideInInspector]
    public int count;

}
