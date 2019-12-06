using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * <summary>Manages the play game menu.</summary>
 */
public class PlayGameMenu : MonoBehaviour
{
    ObjectManager objMgr;
    DataManager dMgr;
    // Start is called before the first frame update
    void Start()
    {
        objMgr = Camera.main.GetComponent<ObjectManager>();
        dMgr = Camera.main.GetComponent<DataManager>();
    }

    public void closePanel()
    {
        objMgr.playGamePanel.SetActive(false);
        objMgr.SetAllButtonsActive(true);
    }

    public void openPanel()
    {
        Start(); // Fixes bug of the game not being initialized.
        gameObject.SetActive(true);
        objMgr.SetAllButtonsActive(false);
    }

    public void singlePlayerClick()
    {
        SaveManager.load(dMgr);
        // Check to see if player has not played yet / cleared a level
        if (SaveManager.existsData())
        {
            if(dMgr.getCompletedLevels().Count > 0)
            {
                // Open level select panel
                SaveManager.deleteData();
                Debug.Log("Called lvl select");
            }
            else
            {
                // open first level
                dMgr.addCompletedLevel(new SerLevel());
                Debug.Log("Create ser vlvl");
            }
        }
        else
        {
            dMgr.Setup();
            SaveManager.save(dMgr);
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        }
    }

    public void multiPlayerClick()
    {
        Debug.Log("Someday this might exist TM");
    }
}
