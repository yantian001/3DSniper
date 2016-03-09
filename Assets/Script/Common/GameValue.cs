using UnityEngine;
using System.Collections;

public class GameValue
{

    public static int mapId = 1;
    /// <summary>
    /// current level
    /// </summary>
    public static int level = 20;

    public static int maxLevelPerMap = 40;


    public static int moneyPerTimeLeft = 5;

    public static GameStatu staus = GameStatu.Init;

    public static bool IsMapLastLevel(int mapid, int levelid)
    {
        if (levelid > maxLevelPerMap)
            return true;
        else
            return false;

    }
}
