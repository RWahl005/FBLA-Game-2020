using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour, IEventHandler
{
    public int id;

    public Sprite notClearedSprite;
    public Sprite clearedSprite;
    public bool cleared;

    private DataManager dm;
    private SpriteRenderer sr;

    private Level lvl;

    private float x;
    private float y;
    private float z;

    void Start()
    {
        dm = Camera.main.GetComponent<DataManager>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        EventHandler.registerHandler(this);
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        z = gameObject.transform.position.z;
        lvl = Camera.main.GetComponent<Level>();
        //Debug.Log(EventHandler.getRegisters());
        onLevelLoad(new LevelLoadEvent());
    }

    [EventHandler]
    public void onLevelLoad(LevelLoadEvent evt)
    {
        List<SerCheckPoint> completedCheckPoints = lvl.getHitCheckPoints();
        Debug.Log("Called");
        foreach(SerCheckPoint check in completedCheckPoints)
        {
            if (check.id == id)
            {
                sr.sprite = clearedSprite;
                cleared = true;
                return;
            }
        }

        sr.sprite = notClearedSprite;
        cleared = false;
    }

    public int getId()
    {
        return id;
    }

    public bool isCleared()
    {
        return cleared;
    }

    public float[] getPosition()
    {
        return new float[] {x, y, z};
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        if (cleared) return;
        cleared = true;
        sr.sprite = clearedSprite;
        lvl.addCheckPoint(this);

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
