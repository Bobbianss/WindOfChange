using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePermissionsManager : MonoBehaviour
{
	//QUESTA CLASSE è L'INTERFACCIA CHE IL GAME MANAGER USA PER GESTIRE I PERMESSI DI GIOCO
	public bool FlyPermission
	{
		get => FindObjectOfType<PlayerMovement>()._flyPermission;

		set => FindObjectOfType<PlayerMovement>()._flyPermission = value;
	}

	public bool MovePermission
	{
		get => FindObjectOfType<PlayerMovement>()._movePermission;

		set => FindObjectOfType<PlayerMovement>()._movePermission = value;
	}

	/*
	public bool gatherPermission
	{
		//todo
	}
	*/

	public bool PickUpPermission
	{
		get => FindObjectOfType<PickUpObject>()._pickUpPermission;

		set => FindObjectOfType<PickUpObject>()._pickUpPermission = value;
	}

	/*
	public bool talkPermission
	{
		//todo
	}
	*/

}
