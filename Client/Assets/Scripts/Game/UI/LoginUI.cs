using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginUI : MonoBehaviour
{
    // [SerializeField] private List<ButtonComponent> m_Buttons = new List<ButtonComponent>();
    // [SerializeField] private List<InputComponent> m_Inputs = new List<InputComponent>();
    // private Dictionary<string, UIComponent> m_Components = new Dictionary<string, UIComponent>();
    // public Dictionary<string, UIComponent> Components => m_Components;

    [SerializeField] private TMP_InputField m_Username;
    [SerializeField] private TMP_InputField m_Password;
    [SerializeField] private Button m_LoginButton;
    
    // private void Start()
    // {
    //     Init();
    // }
    //
    // private void Init()
    // {
    //     // UIManager.Instance.LocalUI = this;
    //     foreach (var button in m_Buttons)
    //         m_Components.Add(button.Key, button);
    //     foreach(var input in m_Inputs)
    //         m_Components.Add(input.Key, input);
    // }
    
    public void Connect()
    {
        string username = m_Username.text;
        string password = m_Password.text;
        NetworkEvents.OnConnectRequest(username, password);
    }
}
