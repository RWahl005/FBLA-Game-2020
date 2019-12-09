using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageEvent
{
    private int damageTaken;
    private bool cancelled;
    public PlayerDamageEvent(int damageTaken)
    {
        this.damageTaken = damageTaken;
        cancelled = false;
    }

    public int getDamageTaken()
    {
        return damageTaken;
    }

    public bool isCancelled()
    {
        return cancelled;
    }

    public void setCancelled(bool value)
    {
        cancelled = value;
    }
}
