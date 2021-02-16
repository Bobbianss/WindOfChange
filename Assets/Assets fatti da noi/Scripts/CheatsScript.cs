using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatsScript : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.N))
		{
			GameState.stateNumber++;
		}
		if (Input.GetKeyDown(KeyCode.B))
		{
			GameState.stateNumber = GameState.stateNumber - 1;
		}
	}
}
