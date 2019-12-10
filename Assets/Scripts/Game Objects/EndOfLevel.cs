using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel : MonoBehaviour
{
    DataManager dm;
    Level lvl;
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
        lvl.setCompleted(true);
        if (dm.containsLevelWithId(lvl.id))
        {
            dm.replaceLevelWithId(Serializer.LevelToSerLevel(lvl), lvl.id);
        }
        else
        {
            dm.addLevel(Serializer.LevelToSerLevel(lvl));
        }
        dm.save();
    }
}
