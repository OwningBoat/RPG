using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStatsManager : MonoBehaviour {

	//public List<PlayerStats> playerList = new List<PlayerStats>();
	public Dictionary<int, PlayerStats> playerList = new Dictionary<int, PlayerStats>();
	
	//TEMP USING SET NAMES FOR PLAYERS
	public string[] pNames = new string[3] {"Joe","Bob","Billy"};
	
	public void initializePlayer() {
		int newID = playerList.Count + 1;
		string newName = pNames[playerList.Count];
		PlayerStats playerStats = new PlayerStats(newID, newName);
		playerList.Add(newID,playerStats);
	}
		
	public string getPlayerName(int playerID) {
		return playerList[playerID].playerName;
	}
	
	public float getAttackSpeed(int playerID) {
		return playerList[playerID].attackSpeed;
	}
	
	public float getPlayerHealth(int playerID) {
		return playerList[playerID].currentHealth;
	}
	
	public float getPlayerMaxHP(int playerID) {
		return playerList[playerID].maxHealth;
	}
		
	// can be used to heal or hurt player.
	public void addHealth(int playerID, int hp) {
		playerList[playerID].addHP(hp);
	}
	
	public void addEXP(int playerID, float exp) {
		playerList[playerID].addEXP(exp);
	}
}
