using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResCoinsCollected : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "Coins Collected: " + ResultData.coinsCollected;
    }
}
