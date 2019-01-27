﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDownItem : ItemBase
{
    void Start()
    {
        _itemType = ItemType.SpeedDown;
    }

    public override PlayerInfo UseItem(PlayerInfo currentInfo)
    {
        AudioManager.Instance.PlaySE("DOWNBufu");
        currentInfo.MoveSpeed = currentInfo.MoveSpeed * 0.7f;
        return currentInfo;
    }
}
