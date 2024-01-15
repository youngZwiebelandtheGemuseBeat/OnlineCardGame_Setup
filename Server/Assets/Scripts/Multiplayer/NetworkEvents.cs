using UnityEngine.Events;
using Riptide;

public static class NetworkEvents
{
  public static event UnityAction<Message> SendMessageToAll;
  public static void Send(Message message) => SendMessageToAll?.Invoke(message);
  public static event UnityAction<Message, ushort> SendMessageToPlayer;
  public static void Send(Message message, ushort id) => SendMessageToPlayer?.Invoke(message, id);
}