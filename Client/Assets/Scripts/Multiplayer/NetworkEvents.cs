using UnityEngine.Events;
using Riptide;

public static class NetworkEvents
{
  public static event UnityAction<string, string> ConnectRequest;
  public static void OnConnectRequest(string username, string password) => ConnectRequest?.Invoke(username, password);
  public static event UnityAction<ushort, string> ConnectSuccess;
  public static event UnityAction<Message> SendMessage;
  public static void OnConnectSuccess(ushort id, string username) => ConnectSuccess?.Invoke(id, username);
  public static void OnSendMessage(Message message) => SendMessage?.Invoke(message);
}
