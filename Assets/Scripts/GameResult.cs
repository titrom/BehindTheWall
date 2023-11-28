using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class GameResult
{
    private static int _point = 0;


    public static int Point { get { return _point; } set { _point = value; } }

    public static string GetResult() => $"{256-_point}/256";
}


