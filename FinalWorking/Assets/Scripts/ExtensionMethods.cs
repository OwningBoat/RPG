using UnityEngine;
using System.Collections;
using System.Collections.Generic;

internal static class ExtensionMethods
{
	// ------------------------------------------
	// Unity Extensions
	// ------------------------------------------
	
	//get list of children
	public static List<GameObject> GetChildren(this GameObject go)
	{
		
		List<GameObject> children = new List<GameObject>();
		
		foreach (Transform tran in go.transform)
		{
			
			children.Add(tran.gameObject);
			
		}
		
		return children;
		
	}
	
}