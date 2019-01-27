﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : ItemBase
{
    void Start()
    {
        _itemType = ItemType.SpeedUp;
    }

    public override PlayerInfo UseItem(PlayerInfo currentInfo)
    {
        currentInfo.MoveSpeed = currentInfo.MoveSpeed * 1.5f;
        return currentInfo;
    }
}