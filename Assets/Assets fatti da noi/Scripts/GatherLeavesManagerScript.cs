using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherLeavesManagerScript : MonoBehaviour
{
	private static int _countLeaves;
	public static int countLeaves
	{
		get => _countLeaves;

		set
		{
			_countLeaves = value;
			if(_countLeaves == 10)
			{
				GameState.AdvanceState();
			}
		}
	}
	public bool _gatherPermission = false;

	
}
