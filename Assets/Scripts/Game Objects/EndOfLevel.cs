using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
    DataManager dm;
    Level lvl;

    public string nextLevel;
    void Start()
    {
        dm = Camera.main.GetComponent<DataManager>();
        lvl = Camera.main.GetComponent<Level>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        ResultData.nextLevel = nextLevel;
        ResultData.checkPointsReached = lvl.getHitCheckPoints().Count;
        ResultData.totalCheckPoints = lvl.totalCheckpoints;
        ResultData.gameOvers = lvl.totalGameOvers;
        ResultData.coinsCollected = lvl.coinsCollected;
        ResultData.hearts = dm.getHealth();
        ResultData.currentLevel = lvl.id;
        lvl.setCompleted(true);

        if (dm.containsLevelWithId(lvl.id))
        {
            dm.replaceLevelWithId(Serializer.LevelToSerLevel(lvl), lvl.id);
        }
        else
        {
            dm.addLevel(Serializer.LevelToSerLevel(lvl));
            dm.addCoins(lvl.getCoinsAmmount());
        }
        dm.save();
        
        SceneManager.LoadScene("Results", LoadSceneMode.Single);
    }
}
