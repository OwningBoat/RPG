using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GUIBattleController : MonoBehaviour
{
    public GameObject[] TimerBars;
    public GameObject[] PartyNames;
    public GameObject[] PartyStats;
    List<GUITimerManager> timerManager = new List<GUITimerManager>();
    bool damaged = false;
    
    void Start() {
    	int playerID = 0;
    	foreach(GameObject timerBar in TimerBars) {
    		// We will use this to do more than just the bars, we will also get the information of each of the party
    		//Set the player Names
    		Text CurrentNameText = PartyNames[playerID].GetComponent<Text>();
			CurrentNameText.text = GameplayManager.psMan.getPlayerName(playerID+1);
    		
    		//Set the player HP
    		Text CurrentStatText = PartyStats[playerID].GetComponent<Text>();
    		CurrentStatText.text = GameplayManager.psMan.getPlayerHealth(playerID+1) + "/" + GameplayManager.psMan.getPlayerMaxHP(playerID+1);
    		
    		//Set the timer parameters..
    		GUITimerManager GUITimer = timerBar.GetComponent<GUITimerManager>();
    		GUITimer.fSpeed = GameplayManager.psMan.getAttackSpeed(playerID+1);
			timerManager.Add (GUITimer);
			playerID++;
    	}
    	
    }
    
    public void damageEvent() {
    	damaged = true;
    }
    
    void Update() {
    	if (damaged) {
    		//Update current HP
    		int playerID = 1;
    		foreach (GameObject timerBar in TimerBars) {
				//Set the player HP
				Text CurrentStatText = PartyStats[playerID].GetComponent<Text>();
				CurrentStatText.text = GameplayManager.psMan.getPlayerHealth(playerID+1) + "/" + GameplayManager.psMan.getPlayerMaxHP(playerID+1);
    		}
    		damaged = false;
    	}
    }
}
