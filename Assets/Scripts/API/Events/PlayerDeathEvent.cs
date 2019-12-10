using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathEvent
{
    private float[] position;
    public PlayerDeathEvent(float[] position)
    {
        this.position = position;
    }

    public float[] getPosition()
    {
        return position;
    }
}
