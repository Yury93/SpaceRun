using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System.Collections.Generic;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private string region,sceneName;
    [SerializeField] private InputField nameRoom;
    [SerializeField] private ListItem itemPrefab;
    [SerializeField] private Transform content;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectToRegion(region);
        if(nameRoom.text.Length <= 0)
        {
            nameRoom.text = "room name...";
        }
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("������������ � �������: "+ PhotonNetwork.CloudRegion);
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("����������� �� �������");
    }
    public void CreateRoomButton()
    {
        if (!PhotonNetwork.IsConnected || nameRoom.text.Length <= 0)
        {
            return;
        }
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(nameRoom.text, roomOptions, TypedLobby.Default);
        PhotonNetwork.LoadLevel(sceneName);
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("������� �������: " + PhotonNetwork.CurrentRoom.Name);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("�� ������� ������� �������!");
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (var info in roomList)
        {
            var listItem = Instantiate(itemPrefab, content);
            if(listItem)
            {
                listItem.SetInfo(info);
                Debug.Log("���� ������ ���������!");
            }

        }
    }
    public override void OnJoinedRoom()
    {
        if (nameRoom.text.Length > 0)
            PhotonNetwork.LoadLevel(sceneName);
    }
    public void JoinButton()
    {
        if(nameRoom.text.Length > 0)
        PhotonNetwork.JoinRoom(nameRoom.text);
    }
}
