using UnityEngine;


[CreateAssetMenu(fileName = "New Item" ,menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    [Header("Attrributes")]
    public int itemID;
    public string itemName;
    public int count;
    public Sprite sprite;
}
