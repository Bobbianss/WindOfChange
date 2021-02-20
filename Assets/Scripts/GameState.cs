using System.Collections;
using System.Collections.Generic;
using UnityEngine;	

public class GameState : MonoBehaviour
{
	private static int _stateNumber = 0;

	private void Start()
	{
		StateNumber = 0;
	}

	public static int StateNumber
	{
		get => _stateNumber;

		set
		{
			_stateNumber = value;
			EventsScript.PropagateEvents(_stateNumber);
			Debug.Log("Stato Attuale:  " + _stateNumber);
		}
	}


	public static void AdvanceState()
	{
		_stateNumber++;
		//Debug.Log("STATO AVANZATO------------------------------------");
	}
}
