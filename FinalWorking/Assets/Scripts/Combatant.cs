using UnityEngine;
using System.Collections;

public class Combatant : MonoBehaviour 
{
    // TODO: Fix variable assignments, otherwise script won't compile - AG 6/10/15
    GameObject controllerObject;
    
    // Set the name that will appear in combat here. If void appears this wasn't set.
	public string characterName = "void";

    // Whether this is a player character or enemy. Player is the default.
	public bool enemy = false;
    int attackDirection = 1;

    // How far into the timer this current character is.
	public float timerProgress;

	public float combatantLevel = 1;

	// How often does the combatant attack. 
	public float attackSpeed = 1;

	// this is used to calculate the total HP. It's set as 3 by default. The higher it is, the more exponential will the HP be relative to the level. 
	public float globalStatGrowth = 3;

	//base HP is the base HP the combatant has, HPGrowth is the ammount he gains per level.
	public float baseHP = 1;
	public float HPGrowth = 1;
	//public float hitPoints = baseHP + (combatantLevel ^ globalStatGrowth) + (combatantLevel * HPGrowth);
	
	public float baseDefense = 1;
	public float defenseGrowth = 1;
	//public float defense = baseDefense + (defenseGrowth * combatantLevel);

	public float baseAttack = 1;
	public float attackGrowth = 1;
	//public float damage = baseAttack + (combatantLevel * AttackGrowth )+ (((combatantLevel ^ globalStatGrowth)/16) / (attackSpeed/10);
	//public float damageTaken = (other guys attack) * (100/100+defense);

	public float experience = 0;

	//levelUp

    int actionState = 0;
    // 0 == not acting
    // 1 == choosing action
    // 2 == melee attack


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
        if (enemy)
        {
            attackDirection = -1;
        }

        controllerObject = GameObject.FindWithTag("CombatController");
        originPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        targetPosition = new Vector3(transform.position.x + (3 * attackDirection) , transform.position.y, transform.position.z);    
    }

    public void DoAction()
    {
        Debug.Log( name + "'s turn to act. Press enter attack.");
        actionState = 1;
    }


    public void AttackEnd()
    {
        CombatController controller = controllerObject.GetComponent<CombatController>();
        timerProgress = 0;
        actionState = 0;
        controller.ResumeCombat();
    }

    void Update ()
    {
        if (actionState == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            actionState = 2;
        }
        if (actionState == 2)
        {
            float step = 12 * Time.deltaTime;
            if (!returning)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            }
            if (transform.position == targetPosition)
            {
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
