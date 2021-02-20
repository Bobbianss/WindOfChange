using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCambioTartaruga : MonoBehaviour //funziona?
{
    public int gameStateOfActivation;
	


	private void OnTriggerEnter(Collider other)
	{
		if (gameStateOfActivation == GameState.StateNumber)
		{
			GameState.StateNumber++;
		}
	}

	 
}
