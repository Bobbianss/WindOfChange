using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePermissionsManager : MonoBehaviour
{
	GameObject tartaruga;
	GameObject umano;
	GameObject capitano;

	//QUESTA CLASSE è L'INTERFACCIA CHE IL GAME MANAGER USA PER GESTIRE I PERMESSI DI GIOCO
	public bool FlyPermission
	{
		get => FindObjectOfType<PlayerMovement>()._flyPermission;
		set => FindObjectOfType<PlayerMovement>()._flyPermission = value;
	}

	public static bool MovePermission
	{
		get => FindObjectOfType<PlayerMovement>()._movePermission;

		set => FindObjectOfType<PlayerMovement>()._movePermission = value;
	}

	
	public static bool gatherPermission
	{
		get => FindObjectOfType<GatherLeavesManagerScript>()._gatherPermission;
		set => FindObjectOfType<GatherLeavesManagerScript>()._gatherPermission = value;

	}
	

	public bool PickUpPermission
	{
		get => FindObjectOfType<PickUpObject>()._pickUpPermission;

		set => FindObjectOfType<PickUpObject>()._pickUpPermission = value;
	}

	public bool talkPermissionTartaruga
	{
		get => tartaruga.GetComponent<Collider>().enabled;
		set => tartaruga.GetComponent<Collider>().enabled = value;
	}
	public bool talkPermissionUmano
	{
		get => umano.GetComponent<Collider>().enabled;
		set => umano.GetComponent<Collider>().enabled = value;
	}
	public bool talkPermissionCapitano
	{
		get => capitano.GetComponent<Collider>().enabled;
		set => capitano.GetComponent<Collider>().enabled = value;
	}
	

}
