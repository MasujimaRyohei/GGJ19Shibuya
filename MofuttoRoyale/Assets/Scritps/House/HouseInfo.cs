using System;
using Random = System.Random;
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

    private static readonly Random mRandom = new Random();

    public HouseInfo()
    {
        this.roofExists = RandomBool();
        this.roofColor = Random<ERoofColor>();
        this.chimneyExists = RandomBool();
        this.windowExists = RandomBool();
    }

    public HouseInfo(bool roofExists, ERoofColor roofColor,bool chimneyExists, bool windowExists)
    {
        this.roofExists = roofExists;
        this.roofColor = roofColor;
        this.chimneyExists = chimneyExists;
        this.windowExists = windowExists;
    }



    private T Random<T>()
    {
        return Enum.GetValues(typeof(T))
            .Cast<T>()
            .OrderBy(c => mRandom.Next())
            .FirstOrDefault();
    }

    private bool RandomBool()
    {
        return UnityEngine.Random.Range(0, 2) == 0;
    }
}
