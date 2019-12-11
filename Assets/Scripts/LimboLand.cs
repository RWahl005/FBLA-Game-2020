using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * On level load change.
 */
public class LimboLand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Level" + LimboLevel.lvlId, LoadSceneMode.Single);
    }
}
