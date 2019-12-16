using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShot : MonoBehaviour
{
    public bool original;
    public float speed;

    private float countdownTimer;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void init(float countdown)
    {
        countdownTimer = countdown;
        original = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (original) return;
        transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
        countdownTimer -= Time.deltaTime;
        if(countdownTimer < 0)
        {
            Destroy(gameObject);
        }
        
    }
}
