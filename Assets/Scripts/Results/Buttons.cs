using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void onNextLevel()
    {
        SceneManager.LoadScene(ResultData.nextLevel, LoadSceneMode.Single);
    }

    public void onTitleScreen()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }
}
