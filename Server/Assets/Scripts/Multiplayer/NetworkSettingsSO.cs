using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Multiplayer/Network/Settings")]
public class NetworkSettingsSO : ScriptableObject
{
  public ushort Port = 7777;
  public ushort MaxPlayers = 4;
}