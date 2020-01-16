using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public bool sample;
    public float speed;
    public float time;

    private float curTime;

    // Start is called before the first frame update
    void Start()
    {
        curTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (sample) return;
        curTime += Time.deltaTime;
        if(curTime > time)
        {
            Destroy(gameObject);
            return;
        }

        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
