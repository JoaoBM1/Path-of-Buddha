using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text optionsPlayerName;
    public Button defaultButton;
    public Button mcdonaldsButton;
    public Button pizzaButton;
    public Button sushiButton;

    private void Awake()
    {
        setPlayerName();
        setInteractibleButton();
    }

    public void setInteractibleButton()
    {
        if(DatabaseManager.hasThemeDefault0 != 1)
        {
            defaultButton.interactable = false;
        }

        if (DatabaseManager.hasThemeMcDonalds1 != 1)
        {
            mcdonaldsButton.interactable = false;
        }

        if (DatabaseManager.hasThemePizza2 != 1)
        {
            pizzaButton.interactable = false;
        }

        if (DatabaseManager.hasThemeSushi3 != 1)
        {
            sushiButton.interactable = false;
        }
    }

    public void setPlayerName()
    {
        if (DatabaseManager.username == null)
        {
            optionsPlayerName.text = "Current Player: Guest";
        }
        else
        {
            optionsPlayerName.text = "Current Player: " + DatabaseManager.username;
        }
    }

    public void setActiveThemeDefault()
    {
        if(DatabaseManager.hasThemeDefault0 == 1)
        {
            DatabaseManager.activeTheme = 0;
            PlayerPrefs.SetInt("activeTheme", DatabaseManager.activeTheme);
        }
    }

    public void setActiveThemeMcDonalds()
    {
        if (DatabaseManager.hasThemeMcDonalds1 == 1)
        {
            DatabaseManager.activeTheme = 1;
            PlayerPrefs.SetInt("activeTheme", DatabaseManager.activeTheme);
            Debug.Log(DatabaseManager.activeTheme);
        }
    }

    public void setActiveThemePizza()
    {
        if (DatabaseManager.hasThemePizza2 == 1)
        {
            DatabaseManager.activeTheme = 2;
            PlayerPrefs.SetInt("activeTheme", DatabaseManager.activeTheme);
        }
    }

    public void setActiveThemeSushi()
    {
        if (DatabaseManager.hasThemeSushi3 == 1)
        {
            DatabaseManager.activeTheme = 3;
            PlayerPrefs.SetInt("activeTheme", DatabaseManager.activeTheme);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
