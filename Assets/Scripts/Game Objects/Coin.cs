using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private DataManager dm;

    private void Start()
    {
        dm = Camera.main.GetComponent<DataManager>();
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
        dm.addCoins(1);
    }

}
