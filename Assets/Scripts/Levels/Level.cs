using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// I CANNOT figure out what I am doing with the data save system.
/// On Rewrite #5. At this pace this game will never get done.
/// </summary>
public class Level : MonoBehaviour, IEventHandler
{
    public int id;
    public int totalCheckpoints = 0;
    public int totalGameOvers = 0;
    public List<SerCheckPoint> hitCheckPoints;
    public List<SerCoin> collectedCoins;
    public bool completed;
    public int coinsCollected;

    private DataManager dm;

    void Start()
    {
        hitCheckPoints = new List<SerCheckPoint>();
        //collectedCoins = new List<SerCoin>();
        EventHandler.registerHandler(this);
        dm = gameObject.GetComponent<DataManager>();
        
    }

    [EventHandler]
    public void gameOver(GameOverEvent evt)
    {
        SerLevel serLvl = dm.getCompletedLevels().Find(isLvlFound);
        if (serLvl != null)
            Serializer.LoadLevel(serLvl, this);
        hitCheckPoints = new List<SerCheckPoint>();
        collectedCoins = new List<SerCoin>();
        EventHandler.callEvent(new LevelLoadEvent());
        totalGameOvers += 1;
    }

    [EventHandler]
    public void PreLevelLoad(PreLevelLoadEvent evt)
    {
        SerLevel serLvl = dm.getCompletedLevels().Find(isLvlFound);
        if (serLvl != null)
            Serializer.LoadLevel(serLvl, this);
        EventHandler.callEvent(new LevelLoadEvent());
    }

    /**
     * Called when the level data is loaded.
     */
    [EventHandler]
    public void OnLevelLoad(LevelLoadEvent evt)
    {
        
    }

    public void addCoin(Coin c)
    {
        collectedCoins.Add(Serializer.CoinToSerCoin(c));
        coinsCollected += 1;
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

    public void setCompleted(bool completed)
    {
        this.completed = completed;
    }

    public bool containsCoinWithId(int id)
    {
        foreach(SerCoin sc in collectedCoins)
        {
            if (sc.id == id) return true;
        }
        return false;
    }

    public int getCoinsAmmount()
    {
        return coinsCollected;
    }
}
