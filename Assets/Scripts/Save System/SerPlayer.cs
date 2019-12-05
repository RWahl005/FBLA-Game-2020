using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SerPlayer
{
    public List<string> baas;
    public List<SerLevel> levelsCleared;
    public int coinsCollected;
    public int health;

    //Might be unused.
    public float jumpBoostLevel; 
}

[System.Serializable]
public class SerLevel
{
    public List<SerCoin> coinsCollected;
    // Might be unused.
    public List<SerCheckPoint> checkPointsReached;
    public int id;
}

[System.Serializable]
public class SerCoin
{
    public int id;
}

//Might go unused
[System.Serializable]
public class SerCheckPoint
{
    public int id;
}
