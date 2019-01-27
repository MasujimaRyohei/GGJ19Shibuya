using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[Serializable]
public class HouseInfo 
{
    [SerializeField] private bool roofExists;
    [SerializeField] private ERoofColor roofColor;
    [SerializeField] private bool chimneyExists;
    [SerializeField] private bool windowExists;

    public bool RoofExists { get { return roofExists; } }
    public ERoofColor RoofColor { get { return roofColor; } }
    public bool ChimneyExists { get { return chimneyExists; } }
    public bool WindowExists { get { return windowExists; } }

    public HouseInfo(bool roofExists, ERoofColor roofColor,bool chimneyExists, bool windowExists)
    {
        this.roofExists = roofExists;
        this.roofColor = roofColor;
        this.chimneyExists = chimneyExists;
        this.windowExists = windowExists;

        Debug.Log(roofExists +" : "+ roofColor + " : " + chimneyExists + " : " + windowExists);
    }

    public static HouseInfo GetRandomHouseInfo()
    {
        return new HouseInfo(RandomBool(), RandomEnum<ERoofColor>(), RandomBool(), RandomBool());
    }

    public static bool RandomBool()
    {
        return Random.Range(0, 2) == 0;
    }

    public static T RandomEnum<T>()
    {
        System.Random mRandom = new System.Random();

        return Enum.GetValues(typeof(T))
            .Cast<T>()
            .OrderBy(c => mRandom.Next())
            .FirstOrDefault();
    }


}
