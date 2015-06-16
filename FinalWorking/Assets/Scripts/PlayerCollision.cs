using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCollision : MonoBehaviour 
{

	public bool collisionUp;
	public bool collisionDown;
	public bool collisionLeft;
	public bool collisionRight;

	public bool showRays = true;

	public float rayDistance;

	public RaycastHit hit;
	public RaycastHit contact;

	public List<GameObject> rayPoints;
	public List<Ray> rays;

	public List<Ray> raysUp;
	public List<Ray> raysDown;
	public List<Ray> raysLeft;
	public List<Ray> raysRight;
	
	
	void Start () 
	{
		rayPoints = new List<GameObject>();
		getRays ();
	}

	//------------------------------------------------------------------------------------------------------
	//CHECK COLIISION OVER AND OVER AND OVER AND OVER AND OVER AND OVER AND OVER AND OVER AND OVER.
	void Update () 
	{
		checkCollision ();

		if (showRays) 
		{
			//drawRaycast();
		}
	}

	//------------------------------------------------------------------------------------------------------
	//check if the kids are alright...
	void getRays()
	{
		List<GameObject> children = gameObject.GetChildren ();
		List<GameObject> children2 = new List<GameObject> ();

		for (int i = 0; i < children.Count; i++)
		{
			if (children[i].name == "RayCasting")
			{
				children2 = children[i].GetChildren();
			}
		}

		for (int i = 0; i < children2.Count; i++)
		{
			rayPoints.Add (children2[i]);
		}
	}

	//------------------------------------------------------------------------------------------------------
	void checkCollision()
	{
		//create lists, be organized.
		List<Ray> raysUp = new List<Ray> ();
		List<Ray> raysDown = new List<Ray> ();
		List<Ray> raysLeft = new List<Ray> ();
		List<Ray> raysRight = new List<Ray> ();

		hit = new RaycastHit ();

		for (int i = 0; i< rayPoints.Count; i++)
		{
			//UP UP UP UP UP UP UP UP 
			if (rayPoints[i].gameObject.name == "up")
			{
				raysUp.Add (new Ray(rayPoints[i].gameObject.transform.position, rayPoints[i].gameObject.transform.up));
			}

			//DOWN DOWN DOWN DOWN DOWN DOWN DOWN DOWN
			if (rayPoints[i].gameObject.name == "down")
			{
				raysDown.Add (new Ray(rayPoints[i].gameObject.transform.position, -rayPoints[i].gameObject.transform.up));
			}

			//LEFT LEFT LEFT LEFT LEFT LEFT LEFT LEFT LEFT
			if (rayPoints[i].gameObject.name == "left")
			{
				raysLeft.Add (new Ray(rayPoints[i].gameObject.transform.position, -rayPoints[i].gameObject.transform.right));
			}

			//RIGHT RIGHT RIGHT RIGHT RIGHT RIGHT RIGHT
			if (rayPoints[i].gameObject.name == "right")
			{
				raysRight.Add (new Ray(rayPoints[i].gameObject.transform.position, rayPoints[i].gameObject.transform.right));
			}
		}
		//check yo self collision
		collisionUp = checkCollision (raysUp);
		collisionDown = checkCollision (raysDown);
		collisionLeft = checkCollision (raysLeft);
		collisionRight = checkCollision (raysRight);
	}

	//INCASE I'M DUMB I'LL USE THIS DEBUG.
	/*
	void drawRaycast()
	{
		//UPWARDS AND AWAYWARDS
		foreach (Ray rUp in raysUp) {
			Debug.DrawRay(rUp.origin, rUp.direction * rayDistance, Color.red);
		}
		//DOWN THE RABBIT HOLE
		foreach(Ray rDown in raysDown) {
			Debug.DrawRay(rDown.origin, rDown.direction * rayDistance, Color.red);
		}
		//TO THE LEFT TO THE LEFT
		foreach(Ray rLeft in raysLeft) {
			Debug.DrawRay(rLeft.origin, rLeft.direction * rayDistance, Color.red);
		}
		//R I G H T.
		foreach (Ray rRight in raysRight) {
			Debug.DrawRay(rRight.origin, rRight.direction * rayDistance, Color.red);
		}
	}*/


	bool checkCollision(List<Ray> rayList)
	{
		for (int i = 0; i < rayList.Count; i++)
		{
			//CHECK WHAT CONTACT IS, IS IT TRIGGER????
			if (Physics.Raycast (rayList[i], out hit, rayDistance + 0.001f))
			{
				if (hit.transform.gameObject.tag == "Environment" ) //|| hit.transform.gameObject.tag == "Environment")
				{
					return true;
				}
				else
				{
				return false;
				}
			}
			
		}
		return false;
	}
}






















