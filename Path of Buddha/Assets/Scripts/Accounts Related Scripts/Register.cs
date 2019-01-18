using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour {

    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(RegisterAccount());
    }

    IEnumerator RegisterAccount()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("https://path-of-buddha-database.000webhostapp.com/register.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("User created");
            SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User creation failed. Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }

    public void GoToLogin()
    {
        SceneManager.LoadScene(0);
    }
}
