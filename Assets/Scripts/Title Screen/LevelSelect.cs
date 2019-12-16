using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public int id;
    DataManager dMgr;
    void Start()
    {
        dMgr = Camera.main.GetComponent<DataManager>();
        if(dMgr.getCompletedLevels().Count >= id - 1)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void OnClick()
    {
        SceneManager.LoadScene("Level" + id, LoadSceneMode.Single);
    }
}
