using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/**
 * Class in charge of saving and loading the data.
 */
public class SaveManager
{
    public static string filePath = Application.persistentDataPath + Path.DirectorySeparatorChar + "saves" + Path.DirectorySeparatorChar + "bryanSave.dat";
    //public static string filePath = Application.dataPath + "/saves/bryanSave.dat";
    public static string directoryPath = Application.persistentDataPath + Path.DirectorySeparatorChar + "saves";
    //public static string directoryPath = Application.dataPath + Path.DirectorySeparatorChar + "saves";

    public static void save(DataManager dm)
    {
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);

        SerPlayer sp = convertDataManager(dm);
        bf.Serialize(file, sp);
        file.Close();
    }

    public static bool load(DataManager dm)
    {
        if (!Directory.Exists(directoryPath))
        {
            return false;
        }
        if (existsData())
        {
            SerPlayer sp;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);

            sp = (SerPlayer)bf.Deserialize(file);
            dm.LoadDataManager(sp);
            file.Close();
            return true;
        }
        return false;
    }

    public static bool existsData()
    {
        return File.Exists(filePath);
    }

    public static void deleteData()
    {
        if(existsData())
            File.Delete(filePath);
    }

    private static SerPlayer convertDataManager(DataManager dm)
    {
        SerPlayer sp = new SerPlayer();
        sp.baas = dm.getBAA();
        sp.coinsCollected = dm.getCoins();
        sp.health = dm.getHealth();
        sp.jumpBoostLevel = dm.getJumpBoost();
        sp.levelsCleared = dm.getCompletedLevels();

        return sp;
    }

    private static void convertSerPlayer(SerPlayer sp, DataManager dm)
    {
        dm.setBAA(sp.baas);
        dm.setCoins(sp.coinsCollected);
        dm.setHealth(sp.health);
        dm.setJumpBoost(sp.jumpBoostLevel);
        dm.setCompletedLevels(sp.levelsCleared);
    }
}
