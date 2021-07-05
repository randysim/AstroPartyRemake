using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class AstroPartyLobby : NetworkManager
{
    [Scene] [SerializeField] private string menuScene = string.Empty;

    [Header("Room")]
    [SerializeField] private NetworkRoomPlayerLobby roomPlayerPrefab;

    public static event Action OnClientConnected;
    public static event Action OnClientDisconnected;
}
