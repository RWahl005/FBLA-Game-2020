using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollowCamera : MonoBehaviour
{

    public float xOffset;
    public float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =  new Vector3(Camera.main.transform.position.x + xOffset, Camera.main.transform.position.y + yOffset, 0);
    }
}
