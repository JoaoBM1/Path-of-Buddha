using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {

    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        WWW www = new WWW("https://path-of-buddha-database.000webhostapp.com/login.php?&name=" + nameField.text + "&password=" + passwordField.text);
        yield return www;
        if (www.text[0] == '0')
        {
            DatabaseManager.username = nameField.text;

            string[] textString = www.text.Split(',');
            DatabaseManager.hasThemeDefault0 = int.Parse(textString[1]);
            DatabaseManager.hasThemeMcDonalds1 = int.Parse(textString[2]);
            DatabaseManager.hasThemePizza2 = int.Parse(textString[3]);
            DatabaseManager.hasThemeSushi3 = int.Parse(textString[4]);
            DatabaseManager.activeTheme = int.Parse(textString[5]);

            SceneManager.LoadScene(2);
        }
        else
        {
            Debug.Log("User login failed. Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }

    public void PlayAsGuest()
    {
        DatabaseManager.username = null;
        DatabaseManager.hasThemeDefault0 = 1;
        DatabaseManager.hasThemeMcDonalds1 = 1;
        DatabaseManager.hasThemePizza2 = 1;
        DatabaseManager.hasThemeSushi3 = 1;
        SceneManager.LoadScene(2);
    }

    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }
}
