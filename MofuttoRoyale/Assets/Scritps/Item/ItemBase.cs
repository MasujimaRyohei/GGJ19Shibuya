using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    protected ItemType _itemType;
    public ItemType ItemType { get => _itemType; }
    public abstract PlayerInfo UseItem(PlayerInfo currentInfo);
}

public enum ItemType
{
    SpeedUp = 1,
    PowerUp = 2,
    PointUp = 3,
    SpeedDown = 4
}
