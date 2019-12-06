using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int heartNumber;

    public Sprite alive;
    public Sprite dead;

    private DataManager dm;

    private int thoughHealth;

    // Start is called before the first frame update
    void Start()
    {
        dm = Camera.main.GetComponent<DataManager>();
        thoughHealth = dm.getHealth();
        if (dm.getHealth() >= heartNumber)
        {
            gameObject.GetComponent<Image>().sprite = alive;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = dead;
        }
    }

    private void FixedUpdate()
    {
        if(dm.getHealth() != thoughHealth)
        {
            thoughHealth = dm.getHealth();
            if (dm.getHealth() >= heartNumber)
            {
                gameObject.GetComponent<Image>().sprite = alive;
            }
            else
            {
                gameObject.GetComponent<Image>().sprite = dead;
            }
        }
    }


    // Add on hit take event.
}
