using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
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
        objMgr.settingsPanel.SetActive(false);
        objMgr.SetAllButtonsActive(true);
    }

    public void openPanel()
    {
        gameObject.SetActive(true);
        objMgr.SetAllButtonsActive(false);
    }
}
