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
		if (Input.GetKeyDown(KeyCode.Y))
		{
			GameState.stateNumber = 13;
		}
		if (Input.GetKeyDown(KeyCode.T))
		{
			FindObjectOfType<PlayerMovement>().speedCheat = 3f;
		}
		if (Input.GetKeyUp(KeyCode.T))
		{
			FindObjectOfType<PlayerMovement>().speedCheat = 1f;
		}

	}

}
