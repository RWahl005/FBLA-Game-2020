using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damageAmount = 0;

    private PlayerManager pm;

    DataManager dm;
    void Start()
    {
        dm = Camera.main.GetComponent<DataManager>();
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        Debug.Log(dm.getHealth());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        if (pm.isInvincible()) return;
        PlayerDamageEvent pde = new PlayerDamageEvent(damageAmount);
        EventHandler.callEvent(pde);
        if (!pde.isCancelled())
        {
            dm.removeHealth(damageAmount);
            pm.startInvincible();
        }
    }
}
