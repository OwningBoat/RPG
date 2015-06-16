using UnityEngine;
using System.Collections;
namespace Completed

{
	using System.Collections.Generic; 
	public class GameManager : MonoBehaviour
	{
		
		public static GameManager instance = null;              // static instance of GameManager which allows it to be accessed by any other script
		private BoardManager boardScript;                       // store a reference to BoardManager which will set up the level
		private int level = 1;                                  // current level #

		void Awake()
		{
			// check if instance already exists
			if (instance == null)
				// if not, set instance to this
				instance = this;			
			// if instance already exists and it's not this:
			else if (instance != this)
				// then destroy this. this enforces singleton pattern, meaning there can only ever be one instance of GameManager
				Destroy(gameObject);    
			// sets this to not be destroyed when reloading scene
			DontDestroyOnLoad(gameObject);
			// get a component reference to the attached BoardManager script
			boardScript = GetComponent<BoardManager>();
			// call the InitGame function to initialize the first level 
			InitGame();
		}

		// initializes the game for each level.
		void InitGame()
		{
			// call the SetupScene function of the BoardManager script, pass it current level number.
			boardScript.SetupScene(level);
		}
	}
}
