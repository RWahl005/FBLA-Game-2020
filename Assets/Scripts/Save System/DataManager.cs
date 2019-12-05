using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    protected int coinsCollected;
    protected int health;
    protected List<string> baas;
    protected List<SerLevel> lvls;

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

}