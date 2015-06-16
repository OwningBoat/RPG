using UnityEngine;
using System;
using System.Collections.Generic;       // lists
using Random = UnityEngine.Random;      // random # generator
namespace Completed

{
	public class BoardManager : MonoBehaviour
	{
		// serializable: you can embed a class w/ sub properties in the inspector
		[Serializable]
		public class Count
		{
			public int minimum;             // min. value for Count class
			public int maximum;             // max. value for Count class

			public Count (int min, int max)
			{
				minimum = min;
				maximum = max;
			}
		}

		public int columns = 8;                                         // # of columns in our game board
		public int rows = 8;                                            // # of rows in our game board
		public Count wallCount = new Count (5, 9);                      // lower & upper limit for random # of walls per level
		public GameObject exit;                                         // prefab to spawn for exit
		public GameObject[] floorTiles;                                 // array of floor prefabs
		public GameObject[] wallTiles;                                  // array of wall prefabs
		public GameObject[] outerWallTiles;                             // array of outer tile prefabs
		
		private Transform boardHolder;                                  // reference to the transform of Board object
		private List <Vector3> gridPositions = new List <Vector3> ();   // possible locations to place tiles
		
		
		// clears list gridPositions & prepares to generate a new board
		void InitialiseList ()
		{
			// clear list gridPositions
			gridPositions.Clear ();
			
			// loop through x axis (columns)
			for(int x = 1; x < columns-1; x++)
			{
				// within each column, loop through y axis (rows)
				for(int y = 1; y < rows-1; y++)
				{
					// at each index add a new Vector3 to list w/ the x & y coordinates of that position
					gridPositions.Add (new Vector3(x, y, 0f));
				}
			}
		}

		// sets up the outer walls & floor (background) of the game board
		void BoardSetup ()
		{
			// instantiate Board & set boardHolder to its transform
			boardHolder = new GameObject ("Board").transform;
			
			// loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles
			for(int x = -1; x < columns + 1; x++)
			{
				// loop along y axis, starting from -1 to place floor or outerwall tiles
				for(int y = -1; y < rows + 1; y++)
				{
					// choose a random tile from our array of floor tile prefabs and prepare to instantiate it
					GameObject toInstantiate = floorTiles[Random.Range (0,floorTiles.Length)];
					
					// check if current position is at board edge, if so choose a random outer wall prefab from array of outer wall tiles
					if(x == -1 || x == columns || y == -1 || y == rows)
						toInstantiate = outerWallTiles [Random.Range (0, outerWallTiles.Length)];
					
					// instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
					
					// set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy
					instance.transform.SetParent (boardHolder);
				}
			}
		}
		
		
		// RandomPosition returns a random position from list gridPositions
		Vector3 RandomPosition ()
		{
			// declare an integer randomIndex, set value to a random number between 0 & the count of items in List gridPositions
			int randomIndex = Random.Range (0, gridPositions.Count);
			
			// declare a variable of type Vector3 called randomPosition, set its value to the entry at randomIndex from List gridPositions
			Vector3 randomPosition = gridPositions[randomIndex];
			
			// remove the entry at randomIndex from the list so that it can't be re-used
			gridPositions.RemoveAt (randomIndex);
			
			// return the randomly selected Vector3 position
			return randomPosition;
		}
		
		
		// layoutObjectAtRandom accepts an array of game objects to choose from along with a minimum and maximum range for the number of objects to create
		void LayoutObjectAtRandom (GameObject[] tileArray, int minimum, int maximum)
		{
			// choose a random number of objects to instantiate within the minimum and maximum limits
			int objectCount = Random.Range (minimum, maximum+1);
			
			// instantiate objects until the randomly chosen limit objectCount is reached
			for(int i = 0; i < objectCount; i++)
			{
				// choose a position for randomPosition by getting a random position from list of available Vector3s stored in gridPosition
				Vector3 randomPosition = RandomPosition();
				
				// choose a random tile from tileArray and assign it to tileChoice
				GameObject tileChoice = tileArray[Random.Range (0, tileArray.Length)];
				
				// instantiate tileChoice at the position returned by RandomPosition w/ no change in rotation
				Instantiate(tileChoice, randomPosition, Quaternion.identity);
			}
		}
		
		
		// SetupScene initializes level & calls the previous functions to lay out the game board
		public void SetupScene (int level)
		{
			// creates the outer walls & floor
			BoardSetup ();
			
			// reset list of gridpositions
			InitialiseList ();
			
			// instantiate a random number of wall tiles based on minimum and maximum, at randomized positions
			LayoutObjectAtRandom (wallTiles, wallCount.minimum, wallCount.maximum);
			
			// instantiate the exit tile in the upper right hand corner of game board
			Instantiate (exit, new Vector3 (columns - 1, rows - 1, 0f), Quaternion.identity);
		}
	}
}