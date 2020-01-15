using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsLvl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "Level " + ResultData.currentLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
