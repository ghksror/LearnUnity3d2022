using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UILoginPopup : MonoBehaviour
{
    public InputField inputEmail;
    public InputField inputPassword;
    public Button btnLogin;
    public Button btnSignUp;
    public Button btnForgotPassword;
    public Button btnClose;
    public Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        this.btnLogin.onClick.AddListener(() => {
            if(string.IsNullOrEmpty(inputEmail.text)|| string.IsNullOrEmpty(inputPassword.text))
            {
                Debug.Log("이메일과 비밀번호를 입력 해주세요");
            }
            else
            {
                Debug.Log(inputEmail.text);
                Debug.Log(inputPassword.text);
            }
        });

        this.btnSignUp.onClick.AddListener(() =>
        {
            Debug.Log("Sign up");
        });

        this.btnForgotPassword.onClick.AddListener(() =>
        {
            Debug.Log("Forgot Password?");
        });

        this.toggle.onValueChanged.AddListener((active) =>
        {
            Debug.LogFormat("active:{0}", active);
        });

    }

    public void Open()
    {
        this.gameObject.SetActive(true);
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
