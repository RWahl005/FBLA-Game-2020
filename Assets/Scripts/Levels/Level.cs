using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// I CANNOT figure out what I am doing with the data save system.
/// On Rewrite #5. At this pace this game will never get done.
/// </summary>
public class Level : MonoBehaviour
{
    public int id;
    public List<SerCheckPoint> hitCheckPoints;
    public List<SerCoin> collectedCoins;

    private DataManager dm;

    void Start()
    {
        hitCheckPoints = new List<SerCheckPoint>();
        collectedCoins = new List<SerCoin>();
        dm = gameObject.GetComponent<DataManager>();

        SerLevel serLvl = dm.getCompletedLevels().Find(isLvlFound);
        if(serLvl != null)
            Serializer.LoadLevel(serLvl, this);
    }

    public void addCoin(Coin c)
    {
        collectedCoins.Add(Serializer.CoinToSerCoin(c));
    }

    public void addCheckPoint(CheckPoint cp)
    {
        hitCheckPoints.Add(Serializer.CheckPointToSerCheckPoint(cp));
    }

    public int getId()
    {
        return id;
    }

    public List<SerCheckPoint> getHitCheckPoints()
    {
        return hitCheckPoints;
    }

    public List<SerCoin> getCollectedCoins()
    {
        return collectedCoins;
    }

    private bool isLvlFound(SerLevel lv)
    {
        return lv.id == id;
    }
}
