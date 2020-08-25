using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Photon.Pun;
public class GameSetupController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CriarJogador();
    }

    // Update is called once per frame
    void CriarJogador()
    {
        print("Player criado");
        PhotonNetwork.Instantiate(Path.Combine("Player", "Player"), Vector3.up, Quaternion.identity);
    }
}
