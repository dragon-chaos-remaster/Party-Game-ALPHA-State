using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using Photon.Realtime;
using Photon.Pun;
public enum GameStates { PAUSADO ,IN_GAME, MENU, CONNECTING_TO_SERVER,EXIT_GAME,DISCONNECTING_FROM_SERVER}
public class GameManager : MonoBehaviourPunCallbacks
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [SerializeField] GameStates statesOfTheGame;

    [SerializeField] GameObject quickStartButton;
    [SerializeField] GameObject quickCancelButton;

    [SerializeField] int roomSize;
    public int multiplayerIndex;

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        statesOfTheGame = GameStates.MENU;
        print("A gente está na conectado na região: " + PhotonNetwork.CloudRegion);
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }
    
    public void QuickStart()
    {
        quickStartButton.SetActive(false);
        quickCancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
        //statesOfTheGame = GameStates.CONNECTING_TO_SERVER;
        print("Starting Session:");
    }
    public void QuickCancel()
    {
        quickCancelButton.SetActive(false);
        quickStartButton.SetActive(true);
        //statesOfTheGame = GameStates.DISCONNECTING_FROM_SERVER;
        
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("Failed to Load Room");
        CreateRoom();
    }

    void CreateRoom()
    {
        int randomRoomNumb = Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = (byte)roomSize
        };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumb, roomOptions);

    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("Loading failed. Trying again...");
        CreateRoom();
    }

    
    public bool Pausar()
    {
        Time.timeScale = 0;
        //statesOfTheGame = GameStates.PAUSADO;
        return true;        
    }
    public bool Despausar()
    {
        Time.timeScale = 1;
        //statesOfTheGame = GameStates.IN_GAME;
        return true;        
    }

    void Update()
    {
        switch (statesOfTheGame)
        {
            case GameStates.PAUSADO:
                break;
            case GameStates.CONNECTING_TO_SERVER:
                
                break;
            case GameStates.MENU:
                quickStartButton.SetActive(true);
                break;
            case GameStates.EXIT_GAME:
                Application.Quit();
                break;
            case GameStates.DISCONNECTING_FROM_SERVER:
                PhotonNetwork.LeaveRoom();
                break;
        }
    }

}
