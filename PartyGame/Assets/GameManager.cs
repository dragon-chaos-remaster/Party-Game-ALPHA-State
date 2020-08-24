using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum GameStates { PAUSADO , ONGAME}
public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [SerializeField] GameStates statesOfTheGame;
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
    void Update()
    {
        switch (statesOfTheGame)
        {
            case GameStates.PAUSADO:
                break;
        }
    }
    public bool Pausar()
    {
        Time.timeScale = 0;
        statesOfTheGame = GameStates.PAUSADO;
        return true;        
    }
    public bool Despausar()
    {
        Time.timeScale = 1;
        statesOfTheGame = GameStates.ONGAME;
        return true;        
    }
    
}
