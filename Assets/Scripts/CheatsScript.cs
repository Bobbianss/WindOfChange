using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatsScript : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.N))
		{
			GameState.StateNumber++;
		}
		if (Input.GetKeyDown(KeyCode.B))
		{
			GameState.StateNumber = GameState.StateNumber - 1;
		}
		if (Input.GetKeyDown(KeyCode.Y))
		{
			GameState.StateNumber = 13;
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
