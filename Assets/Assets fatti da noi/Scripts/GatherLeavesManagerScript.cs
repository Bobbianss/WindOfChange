using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherLeavesManagerScript : MonoBehaviour
{
	public static int countLeaves
	{
		get => countLeaves;

		set
		{
			countLeaves = value;
			if(countLeaves == 10)
			{
				GameState.AdvanceState();
			}
		}
	}
	public bool _gatherPermission = false;

	
}
