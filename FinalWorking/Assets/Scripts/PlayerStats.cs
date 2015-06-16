using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerStats {

	public int playerID;
	public float currentHealth;
	public float maxHealth;
	public float experience;
	float expToLvl;
	public int level;
	public string playerName;
	float damage;
	float defense;
	float baseHP;
	float baseDamage;
	float baseDefense;
	public float attackSpeed = 6;
	float globalStatGrowth = 3f;
	float HPGrowth = 1;
	float attackGrowth = 1;
	float defenseGrowth = 1;
	
	public PlayerStats(int id, string playerName) {
		playerID = id;
		baseHP = 100;
		maxHealth = baseHP;
		currentHealth = baseHP;
		experience = 0;
		expToLvl = 50f;
		this.playerName = playerName;
		baseDamage = 1;
		damage = baseDamage;
		baseDefense = 1;
		defense = baseDefense;
		defense = 1;
		level = 1;
	}
	
	public int getID() {
		return playerID;
	}
	
	public void setHP(float hp) {
		currentHealth = hp;
	}
	
	public void addHP(float hp) {
		currentHealth += hp;
	}
	
	public float getHP() {
		return currentHealth;
	}
	
	public void addEXP(float exp) {
		experience += exp;
		if(experience >= expToLvl) {
			levelUp();
		}
	}
	
	public void setEXP(float exp) {
		experience = exp;
	}
	
	public float getEXP() {
		return experience;
	}
	
	public void levelUp() {
		level++;
		expToLvl = ((expToLvl*2f) + expToLvl * .10f);
		experience = 0f;
		maxHealth = baseHP + (Mathf.Pow(level,globalStatGrowth)) + (level * HPGrowth);
		currentHealth = maxHealth;
		damage = baseDamage + (level * attackGrowth ) + ((Mathf.Pow(level,globalStatGrowth))/16) / (attackSpeed/10);
		defense = baseDefense + (level * defenseGrowth) + ((Mathf.Pow(level,globalStatGrowth))/16);
	}
}
