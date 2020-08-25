using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }
    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }
    public override void OnJoinedRoom()
    {
        print("Entrou na Sala");
        StartGame();
    }
    void StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            print("Starting Gaym");
            PhotonNetwork.LoadLevel(GameManager.Instance.multiplayerIndex);
        }
    }
}
