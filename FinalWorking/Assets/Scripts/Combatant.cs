using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Combatant : MonoBehaviour 
{

	public GameObject controllerObject;
	CombatController controller;

    // Whether this is a player character or enemy. Player is the default.
	public bool enemy = false;
    int attackDirection = -1;
    
    float enemyHP = 50f;

    // How far into the timer this current character is.
	public float timerProgress;

    int actionState = 0;
    // 0 == not acting
	// 1 ==  melee attack

	float enemyAttack;
	float enemyAttackProgress = 0f;
	// Set the character's total timer, in milliseconds. This will be changed to
	// a ratio based on speed at some point in the future. 500 ms is the current default. //[Snow, 6/9/2015]changed to 10000/AttackSpeed ms as default
	// A lower number means a faster character.
	public float timer = 500;
    bool returning = false;

    Vector3 originPosition;
    Vector3 targetPosition;

    // Use this for initialization
    void Start()
    {
		enemyAttack = Random.Range(5,11);
        if (enemy)
        {
            attackDirection = 1;
        }
		controllerObject = GameObject.FindGameObjectWithTag("CombatController");
		controller = controllerObject.GetComponent<CombatController>();
		
        originPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        targetPosition = new Vector3(transform.position.x + (3 * attackDirection) , transform.position.y, transform.position.z);    
    }

    public void DoAction()
    {
        actionState = 1;
    }


    public void AttackEnd()
    {
        
        timerProgress = 0;
        actionState = 0;
        //controller.ResumeCombat();
    }

    void Update ()
    {
    	if(enemy) {
    		enemyAttackProgress += Time.deltaTime;
    		if(enemyAttackProgress >= enemyAttack) {
    			actionState = 1;
    			enemyAttackProgress = 0f;
    		}
    		
    	}
    
        if (actionState == 1)
        {
            float step = 12 * Time.deltaTime;
            if (!returning)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            }
            if (transform.position == targetPosition)
            {
            	if(enemy) {
            		// Enemy attack random player
					int playerID = Random.Range(1,GameplayManager.psMan.playerList.Count+1);
            		GameplayManager.psMan.addHealth(playerID,-10);
            		if(GameplayManager.psMan.getPlayerHealth(playerID) <= 0f) {
						int healthCorrect = Mathf.RoundToInt(Mathf.Abs(GameplayManager.psMan.getPlayerHealth(playerID)));
						GameplayManager.psMan.addHealth(playerID,healthCorrect);
            			Debug.Log(GameplayManager.psMan.getPlayerName(playerID) + " has died! :(");
            		}
            	} else {
            		List<Combatant> enemies = controller.GetEnemyList();
					int eID = Random.Range(0,enemies.Count-1);
					Combatant enemyc = enemies[eID];
            		enemyc.enemyHP -= 30f;
            		if(enemyc.enemyHP <= 0f) {
            			controller.removeCombatant(enemyc);
            			Destroy(enemyc.gameObject);
            		}
            	}
            	returning = true;
            }

            if (returning)
            {
                transform.position = Vector3.MoveTowards(transform.position, originPosition, step);
            }
            if (transform.position == originPosition)
            {
                if (returning == true)
                {
                    AttackEnd();
                }
                returning = false;
            }
        }
    }
    
}
