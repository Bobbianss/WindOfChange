using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherLeavesManagerScript : MonoBehaviour
{
	public static int countLeaves;
	public bool _gatherPermission=false;
	
	public  int countLeavesDestroyed()
	{
		return countLeaves;
	}
}
