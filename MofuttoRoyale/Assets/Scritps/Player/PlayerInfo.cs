using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct PlayerInfo
{
    public int PointRate;
    public float MoveSpeed;
    public float Power;

    public PlayerInfo(int pointRate,float speed, float power)
    {
        PointRate = pointRate;
        MoveSpeed = speed;
        Power = power;
    }
}

// 使わなそう
public enum PlayerID
{
    Player1 = 1,
    Player2 = 2,
    Player3 = 3,
    Player4 = 4
}
