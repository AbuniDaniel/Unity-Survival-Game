using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType {
        apple,
        sword,
        pickaxe,
        axe,
    }

    public ItemType itemType;
    public int amount;
}
