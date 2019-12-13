using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IEventHandler
{
    private DataManager dm;
    private Level lvl;

    private void Start()
    {
        dm = Camera.main.GetComponent<DataManager>();
        lvl = Camera.main.GetComponent<Level>();
        EventHandler.registerHandler(this);
    }

    [EventHandler]
    public void loadLevel(LevelLoadEvent evt)
    {
        if (lvl.containsCoinWithId(id))
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public int id;

    public int getId()
    {
        return id;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        gameObject.SetActive(false);
        lvl.addCoin(this);
    }

}
