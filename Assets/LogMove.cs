using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMove : MonoBehaviour
{
    public bool sample;

    public float time;
    private float calctime;
    private float height = -3.90f;
    // Start is called before the first frame update
    void Start()
    {
        calctime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!sample)
        {
            if(transform.position.y < height)
            {
                transform.position += new Vector3(0, 0.5f * Time.deltaTime, 0);
                return;
            }
            transform.position += new Vector3(-1*Time.deltaTime, 0, 0);
            calctime += Time.deltaTime;
            if(calctime > time)
            {
                Destroy(gameObject);
                return;
            }

        }
    }
}
