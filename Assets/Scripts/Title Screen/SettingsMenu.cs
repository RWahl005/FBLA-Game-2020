using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * <summary>Manages the Settings Menu</summary>
 */
public class SettingsMenu : MonoBehaviour
{
    ObjectManager objMgr;
    // Start is called before the first frame update
    void Start()
    {
        objMgr = Camera.main.GetComponent<ObjectManager>();
    }

    public void closePanel()
    {
        objMgr.settingsPanel.SetActive(false);
        objMgr.SetAllButtonsActive(true);
    }

    public void openPanel()
    {
        objMgr.SetAllButtonsActive(false);
        objMgr.settingsPanel.SetActive(true);
    }
}
