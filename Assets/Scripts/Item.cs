using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Item : ScriptableObject
{
    public string itemName;
    public GameObject physicalRepresentation;
}

[System.Serializable]
public class ItemInstance {
    public Item item;

    public ItemInstance(Item item) {
        this.item = item;
    }
}
