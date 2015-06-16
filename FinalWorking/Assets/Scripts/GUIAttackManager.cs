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

    public void AttackClicked()
    {
        Debug.Log("Attack button clicked");
        gameObject.SetActive(false);
        timerManager.curTime = 0f;
    }
}
