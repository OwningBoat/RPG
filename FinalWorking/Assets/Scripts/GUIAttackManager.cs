using UnityEngine;
using System.Collections;

public class GUIAttackManager : MonoBehaviour
{
    static public GUIAttackManager Instance;
    public GameObject TimerText;
    GUITimerManager timerManager;

    void Awake()
    {
        Instance = this;
        timerManager = TimerText.GetComponent<GUITimerManager>();
    }

    public void AttackClicked(int intMember)
    {
        // TODO: Create DoAttack() method in CombatController.cs
        //DoAttack( intMember );
        Debug.Log( "Character " + intMember.ToString() + " DoAttack()" );
        //Timer = Timer.GetComponent<GUITimerManager>;
        //GetComponent<GUITimerManager>

        Debug.Log("Attack button clicked");
        gameObject.SetActive(false);
        timerManager.curTime = 0f;
    }
}
