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

	void Awake() //deve avvenire prima di start affinché tutto sia settato
	{
		stateInformation = new List<StateInformation>();
		linesFile = eventFile.text.Split("\n"[0]);

		/*
		for(int i=0;i< linesFile.Length;i++)
		{
			Debug.Log(linesFile[i].ToString() + "\n" + "_" +i);
		}
		*/
		foreach (string str in linesFile)
		{	
			string[] vecTemp = str.Split('#');
			stateInformation.Add(new StateInformation(NumberToBool(Int32.Parse(vecTemp[0])), NumberToBool(Int32.Parse(vecTemp[1])),
				NumberToBool(Int32.Parse(vecTemp[2])), NumberToBool(Int32.Parse(vecTemp[3])), NumberToBool(Int32.Parse(vecTemp[4])),
				NumberToBool(Int32.Parse(vecTemp[5])), NumberToBool(Int32.Parse(vecTemp[6])), NumberToBool(Int32.Parse(vecTemp[7])),
				NumberToBool(Int32.Parse(vecTemp[8])), Int32.Parse(vecTemp[9]), Int32.Parse(vecTemp[10]), NumberToBool(Int32.Parse(vecTemp[11])),
				NumberToBool(Int32.Parse(vecTemp[12])), vecTemp[13]));
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
		GamePermissionsManager.GatherPermission = stateTemp.gatherPermission;
		//PickUp_Permission
		GamePermissionsManager.PickUpPermission = stateTemp.pickUpPermission;
		//Object_Permission
		//GamePermissionsManager.CollectObjectPermission = stateTemp.objectPermission;
		//Talk_Permission_Tartaruga1
		GamePermissionsManager.TalkPermissionTartaruga1 = stateTemp.talkPermissionTartaruga1;
		//Talk_Permission_Tartaruga2
		GamePermissionsManager.TalkPermissionTartaruga2 = stateTemp.talkPermissionTartaruga2;
		//Talk_Permission_Umano
		GamePermissionsManager.TalkPermissionUmano = stateTemp.talkPermissionUmano;
		//Talk_Permission_Capitano
		GamePermissionsManager.TalkPermissionCapitano = stateTemp.talkPermissionCapitano;
		//Load_Dialogue_Tartaruga1
		DialogueContentManagerScript.UploadDialogue(stateTemp.loadDialogueTartaruga1,DialogueContentManagerScript.tartaruga1);
		//Load_Dialogue_Tartaruga2
		DialogueContentManagerScript.UploadDialogue(stateTemp.loadDialogueTartaruga2,DialogueContentManagerScript.tartaruga2);
		//Spawn_Tartaruga1
		GamePermissionsManager.SpawnTartarugaBeach = stateTemp.spawnTartarugaBeach;
		//Spawn_Tartaruga2
		GamePermissionsManager.SpawnTartarugaMountain = stateTemp.spawnTartarugaMountain;
		//Tutorial_Text
		//TO DO CODE

		//Debug.Log(stateTemp.ToString()+ "\n");

	}


	public bool NumberToBool(int number) => Convert.ToBoolean(number);
}
