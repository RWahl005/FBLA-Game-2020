using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResHealth : MonoBehaviour
{
    public int id;
    public Sprite full;
    public Sprite none;
    // Start is called before the first frame update
    void Start()
    {
        if(ResultData.hearts >= id)
        {
            gameObject.GetComponent<Image>().sprite = full;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = none;
        }
    }

}
