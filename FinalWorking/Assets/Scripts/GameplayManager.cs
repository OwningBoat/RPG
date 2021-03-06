﻿using UnityEngine;
using System.Collections;

public class GameplayManager : MonoBehaviour
{
    private static GameplayManager instance = null;
    public static PlayerStatsManager psMan = null;
    public static GameplayManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("GameplayManager");
                instance = go.AddComponent<GameplayManager>();
                psMan = go.AddComponent<PlayerStatsManager>();
                DontDestroyOnLoad( go );
            }
            return instance;
        }
    }

    public enum GameState
    {
        //WorldMode,
        //TownMode,
        //BattleMode
		Floor1,
		Floor2,
		Floor3,
		Floor4,
		Battle
    };
	
	Vector3 previousLocation;
	GameState previousState;
    GameState currentState = GameState.Floor1;
	
	public Vector3 SpawnPosition { get; set; }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy( gameObject );
        }        
    }

    void Start()
    {
        ChangeState( currentState );
		for (int i = 0; i < 3; i++) {
			psMan.initializePlayer();
		}
    }

	public GameState getState() {
		return currentState;
	}
	
	public GameState getPreviousState() {
		return previousState;
	}
	
	public void setPreviousState(GameState oldState) {
		previousState = oldState;
	}
	
	public Vector3 getPreviousLocation() {
		return previousLocation;
	}
	
	public void setPreviousLocation(Vector3 OldLocation) {
		previousLocation = OldLocation;
	}

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        switch(currentState)
        {
        case GameState.Floor1:
            Application.LoadLevel( "Floor1" ); //TestWorld - set to Final temp to test spawn location.
            break;
        case GameState.Floor2:
            Application.LoadLevel( "Floor2" );
            break;
		case GameState.Floor3:
			Application.LoadLevel( "Floor3" );
			break;
		case GameState.Floor4:
			Application.LoadLevel( "Floor4" );
			break;
        case GameState.Battle:
            Application.LoadLevel( "Battle" );
        break;
        }
    }
}
