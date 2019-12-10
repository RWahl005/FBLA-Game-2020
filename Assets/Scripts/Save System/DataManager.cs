using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/**
 * Handles the DataManager.
 */
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

    /**
     * Save the game.
     */
    public void save()
    {
        SaveManager.save(this);
    }

    /**
     * Grab the amount of coins.
     */
    public int getCoins()
    {
        return coinsCollected;
    }

    /**
     * Set the amount of coins.
     */
    public void setCoins(int value)
    {
        coinsCollected = value;
    }

    /**
     * Add coins to the coin counter.
     */
    public void addCoins(int amount)
    {
        coinsCollected += amount;
    }

    /**
     * Get health of the player.
     */
    public int getHealth()
    {
        return health;
    }

    /**
     * Set the health of the player.
     */
    public void setHealth(int amount)
    {
        health = amount;
    }

    /**
     * Remove the health of the player.
     */
    public void removeHealth(int amount)
    {
        health -= amount;
    }


    /**
     * Add health points to the user.
     */
    public void addHealth(int amount)
    {
        health += amount;
    }

    /**
     * Get the baa data.
     */
    public List<string> getBAA()
    {
        return baas;
    }

    /**
     * Add a BAA title.
     */
    public void addBAA(string baa)
    {
        baas.Add(baa);
    }

    /**
     * Set the entile BAA list.
     */
    public void setBAA(List<string> baa)
    {
        baas = baa;
    }

    /**
     * Get the list of completed levels.
     */
    public List<SerLevel> getCompletedLevels()
    {
        return lvls;
    }

    /**
     * Set the completed levels list.
     */
    public void setCompletedLevels(List<SerLevel> lvls)
    {
        this.lvls = lvls;
    }

    /**
     * Add a completed level.
     */
    public void addLevel(SerLevel lvl)
    {
        lvls.Add(lvl);
    }

    /**
     * Get the jump boost value.
     */
    public float getJumpBoost()
    {
        return jumpBoostValue;
    }

    /**
     * Set the jump boost level.
     */
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
        EventHandler.callEvent(new PreLevelLoadEvent());
    }

    public bool containsLevelWithId(int id)
    {
        foreach(SerLevel lvl in getCompletedLevels())
        {
            if (lvl.id == id) return true;
        }

        return false;
    }

    public void replaceLevelWithId(SerLevel replacement, int id)
    {
        foreach (SerLevel lvl in getCompletedLevels())
        {
            if (lvl.id == id)
            {
                List<SerLevel> lvls = this.lvls;
                int index = lvls.IndexOf(lvl);
                lvls.Remove(lvl);
                lvls.Insert(index, replacement);
                return;
            }
        }
    }

    /**
     * Intialize the data for the datamanger.
     */
    public void Setup()
    {
        baas = new List<string>();
        coinsCollected = 0;
        health = 6;
        jumpBoostValue = 3;
        lvls = new List<SerLevel>();
    }

}
