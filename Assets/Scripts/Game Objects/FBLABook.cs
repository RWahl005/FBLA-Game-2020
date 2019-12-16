using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBLABook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(70 * Time.deltaTime, 70 * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Debug.Log("TODO: Give this thing a purpose.");
        }
    }
}
