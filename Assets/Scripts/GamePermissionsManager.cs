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
	public void Start()
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

	
	public static bool gatherPermission
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
	public static bool talkPermissionTartaruga1
	{
		get => tartarugaBeach.GetComponent<Collider>().enabled;
		set => tartarugaBeach.GetComponent<Collider>().enabled = value;
	}

	public static bool talkPermissionTartaruga2
	{
		get => tartarugaMountain.GetComponent<Collider>().enabled;
		set => tartarugaMountain.GetComponent<Collider>().enabled = value;
	}

	public static bool talkPermissionUmano
	{
		get => marinaio.GetComponent<Collider>().enabled;
		set => marinaio.GetComponent<Collider>().enabled = value;
	}
	public static bool talkPermissionCapitano
	{
		get => capitano.GetComponent<Collider>().enabled;
		set => capitano.GetComponent<Collider>().enabled = value;
	}

	//Verifica

	public static bool spawnTartarugaBeach
	{	get => tartarugaBeach.activeSelf;
		set => tartarugaBeach.SetActive(value);
	}
	public static bool spawnTartarugaMountain
	{
		get => tartarugaMountain.activeSelf;
		set => tartarugaMountain.SetActive(value);
	}


}
