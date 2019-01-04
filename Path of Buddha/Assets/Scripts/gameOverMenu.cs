using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverMenu : MonoBehaviour {

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
