using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour, IEventHandler
{

    public GameObject gameOver;

    private bool invincible;
    private Color defaultColor;
    private SpriteRenderer renderer;
    private bool isDefaultColor = true;

    // Handles how many hits the player can get.
    private int hits;
    private static bool dead;

    public GameObject defaultPoisition;

    private DataManager dm;
    void Start()
    {
        invincible = false;
        renderer = GetComponent<SpriteRenderer>();
        dm = Camera.main.GetComponent<DataManager>();
        defaultColor = renderer.color;
        EventHandler.registerHandler(this);
        hits = 1;
        respawn();
        dead = false;
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
        if(transform.position.y < -5)
        {
            EventHandler.callEvent(new PlayerDeathEvent(new float[] { transform.position.x, transform.position.y, transform.position.z }));
        }
        if (dead)
        {
            transform.Rotate(new Vector3(0, 0, 50 * Time.deltaTime));
        }
        if(transform.rotation.eulerAngles.z > 90)
        {
            dm.discard();
            dead = false;
            transform.rotation = new Quaternion(0,0,0,0);
            gameObject.transform.position = defaultPoisition.transform.position;
            gameOver.SetActive(false);
            EventHandler.callEvent(new GameOverEvent());
            dm.setHealth(6);
        }
    }

    [EventHandler]
    public void onPlayerDamage(PlayerDamageEvent evt)
    {
        if (isInvincible()) {
            evt.setCancelled(true);
            return;
        }
        changeHit(-evt.getDamageTaken());
        startInvincible();
        if(getHits() < 1)
        {
            EventHandler.callEvent(new PlayerDeathEvent(new float[] { transform.position.x, transform.position.y, transform.position.z }));
        }
    }

    [EventHandler]
    public void onDeath(PlayerDeathEvent evt)
    {
        dm.removeHealth(1);
        if (dm.getHealth() < 1)
        {
            gameOver.SetActive(true);
            dead = true;
        }
        if (dead)
        {
            return;
        }
        List<SerCheckPoint> serCheckPoint = Camera.main.GetComponent<Level>().getHitCheckPoints();
        if(serCheckPoint.Count == 0)
        {
            Vector3 position = defaultPoisition.transform.position;
            transform.position = new Vector3(position.x, position.y, position.z);
            return;
        }
        else
        {
            SerCheckPoint scp = serCheckPoint[serCheckPoint.Count - 1];
            transform.position = new Vector3(scp.x, scp.y, scp.z);
            return;
        }
    }

    public static bool isDead()
    {
        return dead;
    }

    public int getHits()
    {
        return hits;
    }

    public void setHits(int i)
    {
        hits = i;
    }

    public void changeHit(int i)
    {
        hits += i;
    }

    private void respawn()
    {
        List<SerCheckPoint> serCheckPoint = Camera.main.GetComponent<Level>().getHitCheckPoints();
        if (serCheckPoint.Count == 0 || Camera.main.GetComponent<Level>().completed)
        {
            Vector3 position = defaultPoisition.transform.position;
            transform.position = new Vector3(position.x, position.y, position.z);
            return;
        }
        else
        {
            SerCheckPoint scp = serCheckPoint[serCheckPoint.Count - 1];
            transform.position = new Vector3(scp.x, scp.y, scp.z);
            return;
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
