// using InexperiencedDeveloper.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour /* Singleton<UIManager> */
{
    public LoginUI LocalUI;

    // public void Connect()
    // {
    //     if(LocalUI == null)
    //     {
    //         Debug.LogError("No local UI on this scene.");
    //         return;
    //     }
    //     string connectInput = "ConnectInput";
    //     if(!LocalUI.Components.TryGetValue(connectInput, out UIComponent component))
    //     {
    //         Debug.LogError($"No input component found: {connectInput}");
    //         return;
    //     }
    //     InputComponent input = (InputComponent)component;
    //     string username = input.Input.text;
    //     
    //     NetworkEvents.OnConnectRequest(username);
    //     // NetworkManager.Instance.Connect(username);
    // }
}
