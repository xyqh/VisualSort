using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonLib
{
    public static void Swap<T>(ref T a, ref T b)
    {
        T c = a;
        a = b;
        b = c;
    }
}
