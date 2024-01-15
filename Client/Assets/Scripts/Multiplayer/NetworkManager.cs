using Riptide;
using Riptide.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ServerToClientMsg : ushort
{
    ApproveLogin,
}

public enum ClientToServerMsg : ushort
{
    RequestLogin,
}

public class NetworkManager : MonoBehaviour /* Singleton<NetworkManager> */
{
    protected /* override */ void Awake()
    {
        // base.Awake();
        RiptideLogger.Initialize(Debug.Log, Debug.Log, Debug.LogWarning, Debug.LogError, true);
    }

    [SerializeField] private NetworkSettingsSO m_netSettings;
    public Client Client { get; private set; }
    // [SerializeField] private string m_Ip = "127.0.0.1";
    // [SerializeField] private ushort m_Port = 7777;

    // private static string s_LocalUsername;

    private void Start()
    {
        Client = new Client();
        Client.Connected += OnClientConnected;
        Subscribe();
    }

    private void Subscribe()
    {
        NetworkEvents.ConnectRequest += Connect;
        NetworkEvents.SendMessage += OnSendMessage;
    }

    private void Unsubscribe()
    {
        NetworkEvents.ConnectRequest -= Connect;
        NetworkEvents.SendMessage -= OnSendMessage;
    }

    private void OnSendMessage(Message message)
    {
        Client.Send(message);
    }

    private void OnClientConnected(object sender, EventArgs e)
    {
        NetworkEvents.OnConnectSuccess(Client.Id, m_netSettings.LocaLUsername);
        m_netSettings.LocalId = Client.Id;
        // PlayerManager.Instance.SpawnInitialPlayer(s_LocalUsername);
    }

    public void Connect(string username, string password)
    {
        m_netSettings.LocaLUsername = string.IsNullOrEmpty(username) ? $"Guest" : username;
        // TODO: send password and validate
        Client.Connect($"{m_netSettings.IP}:{m_netSettings.Port}");
    }

    private void FixedUpdate()
    {
        Client.Update();
    }

    protected /* override */ void OnDestroy()
    {
        // base.OnDestroy();
        Unsubscribe();
        Client.Connected -= OnClientConnected;
    }
}
