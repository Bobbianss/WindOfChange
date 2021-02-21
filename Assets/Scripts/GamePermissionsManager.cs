using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePermissionsManager : MonoBehaviour
{
	public static GameObject marinaio;
	public static GameObject capitano;
	public static GameObject tartarugaBeach;
	public static GameObject tartarugaMountain;


	//QUESTA CLASSE è L'INTERFACCIA CHE IL GAME MANAGER USA PER GESTIRE I PERMESSI DI GIOCO
	public void Awake()
	{
		tartarugaBeach = GameObject.Find("Tartaruga_1");
		tartarugaMountain = GameObject.Find("Tartaruga_2");
		marinaio = GameObject.Find("Umano");
		capitano = GameObject.Find("Capitano");

	}
	public static bool FlyPermission
	{
		get => FindObjectOfType<PlayerMovement>()._flyPermission;
		set => FindObjectOfType<PlayerMovement>()._flyPermission = value;
	}

	public static bool MovePermission
	{
		get => FindObjectOfType<PlayerMovement>()._movePermission;
		set => FindObjectOfType<PlayerMovement>()._movePermission = value;
	}

	
	public static bool GatherPermission
	{
		get => FindObjectOfType<GatherLeavesManagerScript>()._gatherPermission;
		set => FindObjectOfType<GatherLeavesManagerScript>()._gatherPermission = value;

	}
	

	public static bool PickUpPermission
	{
		get => FindObjectOfType<PickUpObject>()._pickUpPermission;

		set => FindObjectOfType<PickUpObject>()._pickUpPermission = value;
	}
	/*
	public static bool CollectObjectPermission
	{
		get => FindObjectOfType<ObjectCollect>()._objectCollectPermission;

		set => FindObjectOfType<ObjectCollect>()._objectCollectPermission = value;
	}
	*/
	public static bool TalkPermissionTartaruga1
	{
		get => tartarugaBeach.GetComponents<Collider>()[1].enabled;
		set => tartarugaBeach.GetComponents<Collider>()[1].enabled = value;

	}

	public static bool TalkPermissionTartaruga2
	{
		get => tartarugaMountain.GetComponents<Collider>()[1].enabled;
		set => tartarugaMountain.GetComponents<Collider>()[1].enabled = value;

	}

	public static bool TalkPermissionUmano
	{
		get => marinaio.GetComponents<Collider>()[1].enabled;
		set => marinaio.GetComponents<Collider>()[1].enabled = value;
	}
	public static bool TalkPermissionCapitano
	{
		get => capitano.GetComponents<Collider>()[1].enabled;
		set => capitano.GetComponents<Collider>()[1].enabled = value;
	}

	//Verifica

	public static bool SpawnTartarugaBeach
	{	get => tartarugaBeach.activeSelf;
		set => tartarugaBeach.SetActive(value);
	}
	public static bool SpawnTartarugaMountain
	{
		get => tartarugaMountain.activeSelf;
		set => tartarugaMountain.SetActive(value);
	}

	
}
