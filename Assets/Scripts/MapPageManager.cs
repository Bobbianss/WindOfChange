using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPageManager : MonoBehaviour
{
	public Renderer noSelection;

	private void OnMouseEnter()
	{
		GetComponentInChildren<Renderer>().enabled = true;
		noSelection.enabled = false;
	}

	private void OnMouseExit()
	{
		GetComponentInChildren<Renderer>().enabled = false;
		noSelection.enabled = true;
	}
}
