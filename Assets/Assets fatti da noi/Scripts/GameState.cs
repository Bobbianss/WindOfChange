using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState: MonoBehaviour
{
	public static int stateNumber = 0;

	public static void AdvanceState()
	{
		stateNumber++;
	}
}
