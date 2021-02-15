using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCambioTartaruga : MonoBehaviour //funziona?
{
    public int gameStateOfActivation;
	public GameObject tartarugaBeach;
	public GameObject tartarugaMountain;


	private void OnTriggerEnter(Collider other)
	{
		if (gameStateOfActivation == GameState.stateNumber)
		{
			FromBeachToMountain();
		}
	}

	public void FromBeachToMountain()
	{
		tartarugaBeach.GetComponent<Renderer>().enabled = false;
		tartarugaBeach.GetComponent<Collider>().enabled = false;
		tartarugaMountain.GetComponent<Renderer>().enabled = true;
		tartarugaMountain.GetComponent<Collider>().enabled = true;
	}
}
