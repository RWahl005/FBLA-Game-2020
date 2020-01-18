using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BAAMenu : MonoBehaviour
{
    ObjectManager objMgr;
    DataManager dm;
    public List<GameObject> baas;
    private List<string> cacheText = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        //dm = Camera.main.GetComponent<DataManager>();
        //SaveManager.load(dm);
        objMgr = Camera.main.GetComponent<ObjectManager>();
        int i = 1;
        foreach(GameObject obj in baas)
        {
            cacheText.Add(obj.GetComponent<Text>().text);
            if(i != 1)
            {
                obj.SetActive(false);
            }
           i++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void closePanel()
    {
        objMgr.readBAAPanel.SetActive(false);
        objMgr.SetAllButtonsActive(true);
    }

    public void openPanel()
    {
        objMgr = Camera.main.GetComponent<ObjectManager>();
        gameObject.SetActive(true);
        objMgr.SetAllButtonsActive(false);
    }

    public void openBAA(int id)
    {
        int i = 1;
        foreach (GameObject obj in baas)
        {
            obj.SetActive(false);
            i++;
        }

        baas[id].SetActive(true);
    }
}
