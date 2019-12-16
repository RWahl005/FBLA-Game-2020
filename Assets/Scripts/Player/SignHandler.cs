using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * This handles the player's interaction with signs.
 */
public class SignHandler : MonoBehaviour
{
    public GameObject signHelpText;
    public GameObject signMenu;

    public bool isSignOpen;
    public bool isOnSign;
    private Sign activeSign;

    // Start is called before the first frame update
    void Start()
    {
        signHelpText.SetActive(false);
        signMenu.SetActive(false);
        isSignOpen = false;
        isOnSign = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isOnSign && !isSignOpen)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isSignOpen = true;
                signHelpText.SetActive(false);
                signMenu.SetActive(true);
                signMenu.GetComponentInChildren<Text>().text = activeSign.text;
            }
        }
        else if (isSignOpen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isSignOpen = false;
                signHelpText.SetActive(true);
                signMenu.SetActive(false);
                signMenu.GetComponentInChildren<Text>().text = "";
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Sign>() != null)
        {
            signHelpText.SetActive(true);
            isOnSign = true;
            activeSign = collision.GetComponent<Sign>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Sign>() != null)
        {
            signHelpText.SetActive(false);
            isOnSign = false;
        }
    }


}
