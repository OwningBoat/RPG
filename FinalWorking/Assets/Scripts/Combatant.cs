using UnityEngine;
using System.Collections;

public class Combatant : MonoBehaviour 
{

	//public GameObject controllerObject;
	//CombatController controller;

    // Whether this is a player character or enemy. Player is the default.
	public bool enemy = false;
    int attackDirection = -1;

    // How far into the timer this current character is.
	public float timerProgress;

    int actionState = 0;
    // 0 == not acting
	// 1 ==  melee attack


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
            attackDirection = 1;
        }

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
        if (actionState == 1)
        {
            float step = 12 * Time.deltaTime;
            if (!returning)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            }
            if (transform.position == targetPosition)
            {
            	//DAMAGE
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
