using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serializer
{
    public static SerLevel LevelToSerLevel(Level lvl)
    {
        SerLevel sl = new SerLevel();
        sl.coinsCollected = lvl.getCollectedCoins();
        sl.checkPointsReached = lvl.getHitCheckPoints();
        sl.id = lvl.getId();
        sl.completed = lvl.completed;
        return sl;
    }

    [System.Obsolete]
    public static List<SerCoin> CoinsToSerCoins(List<Coin> coins)
    {
        List<SerCoin> output = new List<SerCoin>();
        foreach(Coin c in coins)
        {
            SerCoin sc = new SerCoin();
            sc.id = c.getId();
            output.Add(sc);
        }
        return output;
    }

    [System.Obsolete]
    public static List<SerCheckPoint> CheckPointToSerCheckPoints(List<CheckPoint> cp)
    {
        List<SerCheckPoint> output = new List<SerCheckPoint>();
        foreach (CheckPoint c in cp)
        {
            SerCheckPoint scp = new SerCheckPoint();
            scp.id = c.id;
            output.Add(scp);
        }
        return output;
    }

    public static SerCheckPoint CheckPointToSerCheckPoint(CheckPoint checkPoint)
    {
        SerCheckPoint scp = new SerCheckPoint();
        scp.id = checkPoint.id;
        float[] points = checkPoint.getPosition();

        scp.x = points[0];
        scp.y = points[1];
        scp.z = points[2];

        return scp;
    }

    public static SerCoin CoinToSerCoin(Coin c)
    {
        SerCoin sc = new SerCoin();
        sc.id = c.getId();
        return sc;
    }

    public static void LoadLevel(SerLevel sl, Level lvl)
    {
        // My naming conventions suck.
        lvl.hitCheckPoints = sl.checkPointsReached;
        lvl.collectedCoins = sl.coinsCollected;
        lvl.completed = sl.completed;
    }
}
