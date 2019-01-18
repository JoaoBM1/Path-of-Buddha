using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelector : MonoBehaviour {

    public void GoBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        Time.timeScale = 1f;
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        Time.timeScale = 1f;
    }

    public void PlayLevel4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        Time.timeScale = 1f;
    }

    public void PlayLevel5()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
        Time.timeScale = 1f;
    }
}
