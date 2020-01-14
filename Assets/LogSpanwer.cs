using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpanwer : MonoBehaviour
{
    public float cooldown;
    public GameObject logInstance;
    private float cooldownTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer < 0)
        {
            GameObject left = Instantiate(logInstance);
            left.transform.position = transform.position + new Vector3(0, 0, 0);
            left.GetComponent<LogMove>().sample = false;
            cooldownTimer = cooldown;
        }
    }
}
