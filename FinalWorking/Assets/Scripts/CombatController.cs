using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatController : MonoBehaviour
{
    // TODO: Fix variable assignments, otherwise script won't compile - AG 6/10/15
    List<Combatant> enemyList = new List<Combatant>();
    bool turnPaused = false;

	void Awake ()
    {
        GameObject[] combatantList = GameObject.FindGameObjectsWithTag("Combatant");
		Debug.Log(combatantList.Length);
		foreach (GameObject combatant in combatantList)
		{
            Combatant unit = combatant.GetComponent<Combatant>();
            if (unit.enemy) {
            	Debug.Log("adding enemy " + unit);
            	enemyList.Add(unit);
            }
		}
	}
	public void removeCombatant(Combatant combatant) {
		Debug.Log ("removing enemy " + combatant);
		enemyList.Remove(combatant);
		if(enemyList.Count == 0) {
			//WINNER
			GameplayManager.Instance.SpawnPosition = GameplayManager.Instance.getPreviousLocation();
			GameplayManager.Instance.ChangeState(GameplayManager.Instance.getPreviousState());
		}
	}
	
	public List<Combatant> GetEnemyList() {
		return enemyList;
	}
}
