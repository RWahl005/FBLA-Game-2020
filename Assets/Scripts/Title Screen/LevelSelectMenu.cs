using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMenu : MonoBehaviour
{
    ObjectManager objMgr;
    void Start()
    {
        objMgr = Camera.main.GetComponent<ObjectManager>();
    }

    public void back()
    {
        objMgr.levelSelectPanel.SetActive(false);
        objMgr.playGamePanel.SetActive(true);
    }
}
