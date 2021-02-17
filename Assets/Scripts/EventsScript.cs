using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsScript : MonoBehaviour
{   //Int32.Parse(input)
	public TextAsset eventFile;

	//variabili
	public static List<StateInformation> stateInformation;
	string[] linesFile;

	void Start()
	{
		stateInformation = new List<StateInformation>();
		linesFile = eventFile.text.Split("\n"[0]);

		for(int i=0;i< linesFile.Length;i++)
		{
			Debug.Log(linesFile[i].ToString() + "\n" + "_" +i);
		}

		foreach (string str in linesFile)
		{	
			string[] vecTemp = str.Split('#');
			stateInformation.Add(new StateInformation(numberInBool(Int32.Parse(vecTemp[0])), numberInBool(Int32.Parse(vecTemp[1])),
				numberInBool(Int32.Parse(vecTemp[2])), numberInBool(Int32.Parse(vecTemp[3])), numberInBool(Int32.Parse(vecTemp[4])),
				numberInBool(Int32.Parse(vecTemp[5])), numberInBool(Int32.Parse(vecTemp[6])), numberInBool(Int32.Parse(vecTemp[7])),
				numberInBool(Int32.Parse(vecTemp[8])), Int32.Parse(vecTemp[9]), Int32.Parse(vecTemp[10]), numberInBool(Int32.Parse(vecTemp[11])),
				numberInBool(Int32.Parse(vecTemp[12])), vecTemp[13]));
		}

	}

	public static void PropagateEvents(int index)
	{
		StateInformation stateTemp = new StateInformation();

		stateTemp = stateInformation[index];
		//Fly_Pemission
		GamePermissionsManager.FlyPermission = stateTemp.flyPermission;
		//Move_Permission
		GamePermissionsManager.MovePermission = stateTemp.movePermission;
		//Gather_Permission
		GamePermissionsManager.gatherPermission = stateTemp.gatherPermission;
		//PickUp_Permission
		GamePermissionsManager.PickUpPermission = stateTemp.pickUpPermission;
		//Object_Permission
		//GamePermissionsManager.CollectObjectPermission = stateTemp.objectPermission;
		//Talk_Permission_Tartaruga1
		GamePermissionsManager.talkPermissionTartaruga1 = stateTemp.talkPermissionTartaruga1;
		//Talk_Permission_Tartaruga2
		GamePermissionsManager.talkPermissionTartaruga2 = stateTemp.talkPermissionTartaruga2;
		//Talk_Permission_Umano
		GamePermissionsManager.talkPermissionUmano = stateTemp.talkPermissionUmano;
		//Talk_Permission_Capitano
		GamePermissionsManager.talkPermissionCapitano = stateTemp.talkPermissionCapitano;
		//Load_Dialogue_Tartaruga1
		DialogueContentManagerScript.uploadDialogue(stateTemp.loadDialogueTartaruga1,DialogueContentManagerScript.tartaruga1);
		//Load_Dialogue_Tartaruga2
		DialogueContentManagerScript.uploadDialogue(stateTemp.loadDialogueTartaruga2,DialogueContentManagerScript.tartaruga2);
		//Spawn_Tartaruga1
		GamePermissionsManager.spawnTartarugaBeach = stateTemp.spawnTartarugaBeach;
		//Spawn_Tartaruga2
		GamePermissionsManager.spawnTartarugaMountain = stateTemp.spawnTartarugaMountain;
		//Tutorial_Text
		//TO DO CODE

		Debug.Log(stateTemp.ToString()+ "\n");

	}


	public bool numberInBool (int number)
	{
		bool valore=true;
		if (number == 0)
		{
			valore = false;
		}else if(number == 1)
		{
			valore = true;
		}

		return valore;
	}

	
}
