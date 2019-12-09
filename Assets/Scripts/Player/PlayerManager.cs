using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private bool invincible;
    private Color defaultColor;
    private SpriteRenderer renderer;
    private bool isDefaultColor = true;
    // Start is called before the first frame update
    void Start()
    {
        invincible = false;
        renderer = GetComponent<SpriteRenderer>();
        defaultColor = renderer.color;
    }



    // Update is called once per frame

    double time = 0;
    double flashTime = 0;
    void FixedUpdate()
    {
        if (invincible)
        {
            time += Time.deltaTime;
            flashTime += Time.deltaTime;
            if (flashTime > 0.1)
            {
                if (isDefaultColor)
                {
                    renderer.color = Color.red;
                    isDefaultColor = false;
                }
                else
                {
                    isDefaultColor = true;
                    renderer.color = Color.white;
                }
                flashTime = 0;
            }
            if(time > 0.5)
            {
                invincible = false;
                isDefaultColor = true;
                renderer.color = defaultColor;
                time = 0;
                flashTime = 0;
                return;
            }
        } 
    }

    public bool isInvincible()
    {
        return invincible;
    }

    public void startInvincible()
    {
        invincible = true;
    }
}
