using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResCheckPoints : MonoBehaviour
{
    public int id;
    public Sprite notReached;
    public Sprite reached;


    void Start()
    {
        if(id > ResultData.totalCheckPoints)
        {
            gameObject.SetActive(false);
        }
        if(id <= ResultData.checkPointsReached)
        {
            gameObject.GetComponent<Image>().sprite = reached;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = notReached;
        }
    }

}
