using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    ObjectManager objMgr;
    // Start is called before the first frame update
    void Start()
    {
        objMgr = Camera.main.GetComponent<ObjectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closePanel()
    {
        objMgr.helpPanel.SetActive(false);
        objMgr.SetAllButtonsActive(true);
    }

    public void openPanel()
    {
        objMgr = Camera.main.GetComponent<ObjectManager>();
        gameObject.SetActive(true);
        objMgr.SetAllButtonsActive(false);
    }
}
