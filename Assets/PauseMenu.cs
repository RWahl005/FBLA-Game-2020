using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPause = false;

    public GameObject pause;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.isPause = true;
            SignHandler sh = Camera.main.GetComponent<Level>().player.GetComponent<SignHandler>();
            sh.signMenu.SetActive(false);
            sh.signHelpText.SetActive(false);
            pause.SetActive(true);
        }
    }

    public void closeMenu()
    {
        pause.SetActive(false);
        PauseMenu.isPause = false;
        SignHandler sh = Camera.main.GetComponent<Level>().player.GetComponent<SignHandler>();
        sh.signMenu.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void titleScreen()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }
}
