using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevMenu : MonoBehaviour
{

    public GameObject devmenu;
    ObjectManager objMgr;
    // Start is called before the first frame update
    void Start()
    {
        objMgr = Camera.main.GetComponent<ObjectManager>();
        devmenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !devmenu.activeSelf)
        {
            foreach (GameObject obj in objMgr.getPanels())
            {
                if (obj == null) continue;
                obj.SetActive(false);
            }
            objMgr.SetAllButtonsActive(false);
            devmenu.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            objMgr.SetAllButtonsActive(true);
            devmenu.SetActive(false);
        }
    }

    public void onTestLevel()
    {
        SceneManager.LoadScene("Level0", LoadSceneMode.Single);
    }

    public void deleteSaveData()
    {
        SaveManager.deleteData();
    }
}
