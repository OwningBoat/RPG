using UnityEngine;
using System.Collections;

public class UIEvents : MonoBehaviour
{
    public void ChangeToWorldMode()
    {
        GameplayManager.Instance.ChangeState( GameplayManager.GameState.WorldMode );
    }

    public void ChangeToTownMode()
    {
        GameplayManager.Instance.ChangeState( GameplayManager.GameState.TownMode );
    }

    public void ChangeToBattleMode()
    {
        GameplayManager.Instance.ChangeState( GameplayManager.GameState.BattleMode );
    }
}
