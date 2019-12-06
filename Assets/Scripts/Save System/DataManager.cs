using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int coinsCollected;
    private int health;
    private List<string> baas;
    private List<SerLevel> lvls;

    protected float jumpBoostValue;

    void Start()
    {
        SaveManager.load(this);
    }

    public void save()
    {
        SaveManager.save(this);
    }

    public int getCoins()
    {
        return coinsCollected;
    }

    public void setCoins(int value)
    {
        coinsCollected = value;
    }

    public void addCoins(int amount)
    {
        coinsCollected += amount;
    }

    public int getHealth()
    {
        return health;
    }

    public void setHealth(int amount)
    {
        health = amount;
    }

    public void removeHealth(int amount)
    {
        health += amount;
    }

    public void addHealth(int amount)
    {
        health += amount;
    }

    public List<string> getBAA()
    {
        return baas;
    }

    public void addBAA(string baa)
    {
        baas.Add(baa);
    }

    public void setBAA(List<string> baa)
    {
        baas = baa;
    }

    public List<SerLevel> getCompletedLevels()
    {
        return lvls;
    }

    public void setCompletedLevels(List<SerLevel> lvls)
    {
        this.lvls = lvls;
    }

    public void addCompletedLevel(SerLevel lvl)
    {
        lvls.Add(lvl);
    }

    public float getJumpBoost()
    {
        return jumpBoostValue;
    }

    public void setJumpBoost(float value)
    {
        jumpBoostValue = value;
    }

    /**
     * Load SerPlayer to the DataManager.
     */
    public void LoadDataManager(SerPlayer sp)
    {
        this.baas = sp.baas == null ? new List<string>() : sp.baas;
        this.coinsCollected = sp.coinsCollected == 0 ? 0 :  sp.coinsCollected;
        this.health = sp.health == 0 ? 5 : sp.health;
        this.jumpBoostValue = sp.jumpBoostLevel;
        this.lvls = sp.levelsCleared == null ? new List<SerLevel>() : sp.levelsCleared;
    }

    public void Setup()
    {
        baas = new List<string>();
        coinsCollected = 0;
        health = 6;
        jumpBoostValue = 3;
        lvls = new List<SerLevel>();
    }

}