using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : ItemBase
{
    void Start()
    {
        _itemType = ItemType.PowerUp;
    }

    public override PlayerInfo UseItem(PlayerInfo currentInfo)
    {
        AudioManager.Instance.PlaySE("UPBufu");
        currentInfo.Power = currentInfo.Power * 1.5f;
        return currentInfo;
    }
}
