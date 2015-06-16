using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {

	public Transform target;
	//Changable key settings, change by going to the player object.
	public KeyCode fwd;
	public KeyCode back;
	public KeyCode left;
	public KeyCode right;
	public KeyCode interact;
	bool talkAble1;
	bool talkAble2;
	bool moving = false;
	bool battleArea;
	int battle;

	public GameObject talkNotifier;

	//How fast the player will move.
	public float playerSpeed;

	//Reference to the collision stuff
	private PlayerCollision collisions;

	void Start() 
	{
		transform.position = GameplayManager.Instance.SpawnPosition;
		collisions = GetComponent<PlayerCollision>();
		talkNotifier.SetActive(false);
		battle = 0;
	}

	void Update () {

		//How to move player!
		Vector3 pos = transform.position;
		if (Input.GetKey (fwd) && !collisions.collisionUp) {
			pos.y += playerSpeed * Time.deltaTime;
			transform.position = pos;
			moving = true;
		} 
		else if (Input.GetKey (back) && !collisions.collisionDown) {
			pos.y -= playerSpeed * Time.deltaTime;
			transform.position = pos;
			moving = true;
		} 
		else if (Input.GetKey (left) && !collisions.collisionLeft) {
			pos.x -= playerSpeed * Time.deltaTime;
			transform.position = pos;
			moving = true;
		} 
		else if (Input.GetKey (right) && !collisions.collisionRight) {
			pos.x += playerSpeed * Time.deltaTime;
			transform.position = pos;
			moving = true;
		}
		else
		{
			moving = false;
		}
		//dialogue
		if (Input.GetKeyDown (interact) && talkAble1 == true) {
			Debug.Log ("D1");
		}
		else if (Input.GetKeyDown (interact) && talkAble2 == true) {
			Debug.Log ("D2");
		}

		if (battleArea && moving)
		{
			//Debug.Log ("looking for enemies" + battle);
			battle = Random.Range (0, 100);
			if (battle == 1)
			{
				Debug.Log ("Battle!");
				GameplayManager.Instance.SpawnPosition = Vector3.zero;
				GameplayManager.Instance.ChangeState( GameplayManager.GameState.Battle );
			}
		}
	}
	//Check if the player is in a Dialogue zone.
	void OnTriggerEnter(Collider other)
	{
		//DIALOGUE DIALOGUE DIALOGUE DIALOGUE DIALOGUE DIALOGUE DIALOGUE DIALOGUE DIALOGUE DIALOGUE DIALOGUE DIALOGUE DIALOGUE DIALOGUE
		if (other.CompareTag ("Dialogue1")) //repeat for # of Dialogue boxes.
		{
			Debug.Log ("ready to talk 1");
			talkAble1 = true;
			talkNotifier.SetActive(true);
		}
		if (other.CompareTag ("Dialogue2"))
		{
			Debug.Log ("Ready to talk 2");
			talkAble2 = true;
			talkNotifier.SetActive(true);
		}
		if (other.CompareTag ("Battle"))
		{
			battleArea = true;
			Debug.Log ("BattleArea true");
		}
		//SCENE CHANGE SCENE CHANGE SCENE CHANGE SCENE CHANGE SCENE CHANGE SCENE CHANGE SCENE CHANGE SCENE CHANGE SCENE CHANGE SCENE CHANGE
		if (other.CompareTag("Floor2"))
		{
			GameplayManager.Instance.SpawnPosition = Vector3.zero;
			GameplayManager.Instance.ChangeState( GameplayManager.GameState.Floor2 );
		}
		if (other.CompareTag("Floor3"))
		{
			GameplayManager.Instance.SpawnPosition = Vector3.zero;
			GameplayManager.Instance.ChangeState( GameplayManager.GameState.Floor3 );
		}
		if (other.CompareTag("Floor4"))
		{
			GameplayManager.Instance.SpawnPosition = Vector3.zero;
			GameplayManager.Instance.ChangeState( GameplayManager.GameState.Floor4 );
		}
		if (other.CompareTag("Floor1"))
		{
			GameplayManager.Instance.SpawnPosition = Vector3.zero;
			GameplayManager.Instance.ChangeState( GameplayManager.GameState.Floor1 );
		}

	}
  //make the player unable to talk when they lave a Dialogue zone.
	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag ("Dialogue1")) //repeat for # of Dialogue boxes.
		{
			Debug.Log ("can not talk 1");
			talkAble1 = false;
			talkNotifier.SetActive(false);
		}
		if (other.CompareTag ("Dialogue2")) //repeat for # of Dialogue boxes.
		{
			Debug.Log ("can not talk 2");
			talkAble2 = false;
			talkNotifier.SetActive(false);
		}
		if (other.CompareTag ("Battle"))
		{
			battleArea = false;
			Debug.Log ("Battle Area false");
		}
	}
}
