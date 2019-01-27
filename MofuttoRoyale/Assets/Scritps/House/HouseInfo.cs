using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[Serializable]
public class HouseInfo
{
    [SerializeField] private ERoofColor roofColor;
    [SerializeField] private bool chimneyExists;
    [SerializeField] private bool windowExists;

    public ERoofColor RoofColor { get { return roofColor; } }
    public bool ChimneyExists { get { return chimneyExists; } }
    public bool WindowExists { get { return windowExists; } }

   static System.Random mRandom = new System.Random();

    public HouseInfo(ERoofColor roofColor, bool chimneyExists, bool windowExists)
    {
        this.roofColor = roofColor;
        this.chimneyExists = chimneyExists;
        this.windowExists = windowExists;

        Debug.Log(roofColor + " : " + chimneyExists + " : " + windowExists);
    }

    public static HouseInfo GetRandomHouseInfo()
    {
        return new HouseInfo(RandomEnum<ERoofColor>(), RandomBool(), RandomBool());
    }

    public static bool RandomBool()
    {
        return Random.Range(0, 2) == 0;
    }

    public static T RandomEnum<T>()
    {

        return Enum.GetValues(typeof(T))
            .Cast<T>()
            .OrderBy(c => mRandom.Next())
            .FirstOrDefault();
    }
}