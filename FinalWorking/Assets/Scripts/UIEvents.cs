using UnityEngine;
using System.Collections;

public class UIEvents : MonoBehaviour
{
    public void ChangeToWorldFloor1()
    {
        GameplayManager.Instance.ChangeState( GameplayManager.GameState.Floor1 );
    }

    public void ChangeToTownFloor2()
    {
        GameplayManager.Instance.ChangeState( GameplayManager.GameState.Floor2 );
    }

    public void ChangeToBattleFloor3()
    {
        GameplayManager.Instance.ChangeState( GameplayManager.GameState.Floor3 );
    }
	public void ChangeToBattleFloor4()
	{
		GameplayManager.Instance.ChangeState( GameplayManager.GameState.Floor4 );
	}
	public void ChangeToBattle()
	{
		GameplayManager.Instance.ChangeState( GameplayManager.GameState.Battle );
	}
}
