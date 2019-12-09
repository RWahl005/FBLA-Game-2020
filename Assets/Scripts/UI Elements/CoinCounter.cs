using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    DataManager dm;
    Text txt;
    // Start is called before the first frame update
    void Start()
    {
       dm = Camera.main.GetComponent<DataManager>();
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = formatCoins(dm.getCoins());
    }

    string formatCoins(int value)
    {
        if(value < 10)
        {
            return "00" + value;
        }
        if(value > 9 && value < 100)
        {
            return "0" + value;
        }
        return value.ToString();
    }
}
