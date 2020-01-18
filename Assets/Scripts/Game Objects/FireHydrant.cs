using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHydrant : MonoBehaviour
{
    public float cooldown;
    public float waterDestroy;
    private float cooldownTimer;
    private Level lvl;
    private ObjectHandler obm;
    // Start is called before the first frame update
    void Start()
    {
        lvl = Camera.main.GetComponent<Level>();
        obm = Camera.main.GetComponent<ObjectHandler>();
        cooldownTimer = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isPause) return;
        if(Mathf.Abs(lvl.player.transform.position.x - gameObject.transform.position.x) < 10)
        {
            cooldownTimer -= Time.deltaTime;
            if(cooldownTimer < 0)
            {
                GameObject left = Instantiate(obm.waterShotLeft);
                left.transform.position = transform.position + new Vector3(0, 0, 0);
                left.GetComponent<WaterShot>().init(waterDestroy);
                GameObject right = Instantiate(obm.waterShotRight);
                right.transform.position = transform.position + new Vector3(0, 0, 0);
                right.GetComponent<WaterShot>().init(waterDestroy);

                cooldownTimer = cooldown;
            }
        }
    }
}
