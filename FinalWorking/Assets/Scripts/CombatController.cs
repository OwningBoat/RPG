using UnityEngine;
using System.Collections;

public class CombatController : MonoBehaviour
{
    // TODO: Fix variable assignments, otherwise script won't compile - AG 6/10/15
	/*ArrayList combatantList = new ArrayList();

	public GameObject combatant01;
	public GameObject combatant02;
	public GameObject combatant03;*/
    GameObject[] combatantList;
    bool turnPaused = false;


	void Start ()
    {
        combatantList = GameObject.FindGameObjectsWithTag("Combatant");

		foreach (GameObject combatant in combatantList)
		{
            Combatant unit = combatant.GetComponent<Combatant>();
            unit.timerProgress = Random.Range(0, unit.timer);
		}
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!turnPaused)
        {
            foreach (GameObject combatant in combatantList)
            {
                Combatant unit = combatant.GetComponent<Combatant>();
                unit.timerProgress += 1000 * Time.deltaTime;
                if (unit.timerProgress >= unit.timer)
                {
                    turnPaused = true;
                    Debug.Log("PAUSE");
                    unit.DoAction();
                }
            }
        }
	}

    public void ResumeCombat()
    {
        turnPaused = false;
    }
    
}
