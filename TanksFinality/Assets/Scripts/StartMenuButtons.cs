using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenuButtons : MonoBehaviour {

    public GameObject loginForm;
    public GameObject registrationForm;

    public Text loginFormErrorText;
    public Text registrationFromErrorText;

    public InputField loginFormLoginValue;
    public InputField loginFormPassValue;

    public InputField regFormLoginValue;
    public InputField regFormPassValue;

    public void Enter()
    {
        GameObject.FindWithTag("SoundButton").GetComponent<AudioSource>().Play();
        loginForm.SetActive(!loginForm.activeSelf);

        loginFormErrorText.text = "";
    }

    public void Registration()
    {
        GameObject.FindWithTag("SoundButton").GetComponent<AudioSource>().Play();
        registrationForm.SetActive(!registrationForm.activeSelf);
    }

    public void Exit()
    {
        GameObject.FindWithTag("SoundButton").GetComponent<AudioSource>().Play();
        Application.Quit();
    }

    public void loginForm_EnterButtonClick()
    {
        GameObject.FindWithTag("SoundButton").GetComponent<AudioSource>().Play();
        
        if (loginFormLoginValue.text == "" || loginFormPassValue.text == "")
        {
            loginFormErrorText.text = "Login or password is empty!";
        }
        else if (loginFormLoginValue.text == "11" && loginFormPassValue.text == "11")
        {
            Application.LoadLevel(2);
        }
        else
        {
            loginFormErrorText.text = "Login or password are wrong!";
        }       
        
    }

    public void loginForm_CancelButtonClick()
    {
        GameObject.FindWithTag("SoundButton").GetComponent<AudioSource>().Play();
        loginForm.SetActive(!loginForm.activeSelf);

        loginFormErrorText.text = "";
    }

    public void registrationForm_ConfirmButtonClick()
    {
        GameObject.FindWithTag("SoundButton").GetComponent<AudioSource>().Play();
        
        if (loginFormLoginValue.text == "" || loginFormPassValue.text == "")
        {
            loginFormErrorText.text = "Login or password is empty!";
        }
        else
        {
            // Записать нового игрока в базу данных
            Application.LoadLevel(1);
        }
    }

    public void registrationForm_CancelButtonClick()
    {
        GameObject.FindWithTag("SoundButton").GetComponent<AudioSource>().Play();
        registrationForm.SetActive(!registrationForm.activeSelf);
    }

    
}