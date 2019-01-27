using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    protected ItemType ItemType;
}

public enum ItemType
{
    SpeedUp = 1,
    PowerUp = 2,
    PointUp = 3,
    SpeedDown = 4
}
