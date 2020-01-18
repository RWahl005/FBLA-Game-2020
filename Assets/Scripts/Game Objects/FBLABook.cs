using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBLABook : MonoBehaviour
{
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if(Camera.main.GetComponent<DataManager>().getBAA().Contains(id + ""))
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isPause) return;
        gameObject.transform.Rotate(new Vector3(70 * Time.deltaTime, 70 * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Camera.main.GetComponent<DataManager>().addBAA(id + "");
        }
    }
}
