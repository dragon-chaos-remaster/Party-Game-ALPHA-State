using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    //public override void OnConnectedToMaster()
    //{
    //    print("A gente está na conectado na região: " + PhotonNetwork.CloudRegion);
    //}
}
