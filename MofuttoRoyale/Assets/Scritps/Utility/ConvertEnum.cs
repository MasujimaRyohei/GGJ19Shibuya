using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConvertEnum
{
    public static TEnum ConvertToEnum<TEnum>(int number)
    {
        return (TEnum)Enum.ToObject(typeof(TEnum), number);
    }
}
