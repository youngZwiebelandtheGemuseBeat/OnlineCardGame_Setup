// using InexperiencedDeveloper.Core;
using Riptide;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour /* Singleton<PlayerManager> */
{
    [SerializeField] private NetworkSettingsSO m_netSettings;
    [SerializeField] private GameObject m_PlayerPrefab;
    private static GameObject s_PlayerPrefab;
    private static Dictionary<ushort, Player> s_Players = new Dictionary<ushort, Player>();
    public static Player GetPlayer(ushort id)
    {
        s_Players.TryGetValue(id, out Player player);
        return player;
    }
    public static bool RemovePlayer(ushort id)
    {
        if (s_Players.TryGetValue(id, out Player player))
        {
            s_Players.Remove(id);
            return true;
        }
        return false;
    }

    // public Player LocalPlayer => GetPlayer(m_netSettings.LocalId);
    // public bool IsLocalPlayer(ushort id) => id == LocalPlayer.Id;
    private static ushort s_localId = ushort.MaxValue;

    /* protected override */ private void Awake()
    {
        // base.Awake();
        s_PlayerPrefab = m_PlayerPrefab;
        Subscribe();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        NetworkEvents.ConnectSuccess += SpawnInitialPlayer;
    }

    private void Unsubscribe()
    {
        NetworkEvents.ConnectSuccess -= SpawnInitialPlayer;
    }

    public void SpawnInitialPlayer(ushort id, string username)
    {
        Player player = Instantiate(s_PlayerPrefab, Vector3.zero, Quaternion.identity).GetComponent<Player>();
        player.name = $"{username} -- LOCAL PLAYER (WAITING FOR SERVER)";
        // ushort id = NetworkManager.Instance.Client.Id;
        s_localId = id;
        player.Init(id, username, true);
        s_Players.Add(id, player);
        player.RequestInit();
    }

    private static void InitializeLocalPlayer()
    {
        Player local = s_Players[s_localId];
        local.name = $"{local.Username} -- {local.Id} -- LOCAL";
    }

    // MESSAGE RECEIVING
    [MessageHandler((ushort)ServerToClientMsg.ApproveLogin)]
    private static void ReceiveApproveLogin(Message message)
    {
        bool approve = message.GetBool();
        
        if (approve)
        {
            InitializeLocalPlayer();
        }
    }
}
