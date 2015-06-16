using UnityEngine;
using System.Collections;

public class GameplayManager : MonoBehaviour
{
    private static GameplayManager instance = null;
    public static GameplayManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("GameplayManager");
                instance = go.AddComponent<GameplayManager>();
                DontDestroyOnLoad( go );
            }
            return instance;
        }
    }

    public enum GameState
    {
        WorldMode,
        TownMode,
        BattleMode
    };

    GameState currentState = GameState.WorldMode;
	
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
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        switch(currentState)
        {
        case GameState.WorldMode:
            Application.LoadLevel( "Final" ); //TestWorld - set to Final temp to test spawn location.
            break;
        case GameState.TownMode:
            Application.LoadLevel( "TestTown" );
            break;
        case GameState.BattleMode:
            Application.LoadLevel( "TestBattle" );
        break;
        }
    }
}
