using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * <summary>
 * How to access:
 * Use: Camera.mainCamera.GetComponent<ObjectManager>();
 * </summary>
 */
public class ObjectManager : MonoBehaviour
{
    public GameObject exitGameButton;
    public GameObject playGameButton;
    public GameObject settingsButton;
    public GameObject readBAAButton;
    public GameObject helpButton;

    public GameObject playGamePanel;
    public GameObject settingsPanel;
    public GameObject helpPanel;
    public GameObject readBAAPanel;

    /**
     * <summary>Get the list of lower buttons.</summary>
     * <returns>The list of button gameobjects.</returns>
     * 
     */
    public List<GameObject> getLowerButtons()
    {
        List<GameObject> buttons = new List<GameObject>();
        buttons.Add(playGameButton);
        buttons.Add(settingsButton);
        buttons.Add(readBAAButton);
        buttons.Add(helpButton);
        return buttons;
    }

    /**
     * <summary>Get the list of panels.</summary>
     */
    public List<GameObject> getPanels()
    {
        List<GameObject> buttons = new List<GameObject>();
        buttons.Add(playGamePanel);
        buttons.Add(settingsPanel);
        buttons.Add(helpPanel);
        buttons.Add(readBAAPanel);
        return buttons;
    }

    /**
     * <summary>Set all of the buttons to active or not active.</summary>
     */
    public void SetAllButtonsActive(bool value)
    {
        foreach (GameObject obj in getLowerButtons())
        {
            if (obj != null)
            {
                obj.SetActive(value);
            }
        }
    }

    void Start()
    {
        // Hide all of the panels by default.
        foreach(GameObject obj in getPanels())
        {
            if(obj != null)
            {
                obj.SetActive(false);
            }
        }
    }
}
