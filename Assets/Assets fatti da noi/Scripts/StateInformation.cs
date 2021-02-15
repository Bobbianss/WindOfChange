using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateInformation
{
bool flyPermission;
bool movePermission;
bool gatherPermission;
bool pickUpPermission;
bool objectPermission;
bool talkPermissionTartaruga1;
bool talkPermissionTartaruga2;
bool talkPermissionUmano;
bool talkPermissionCapitano;
int loadDialogueTartaruga1;
int loadDialogueTartaruga2;
bool spawnTartaruga1;
bool spawnTartaruga2;
string tutorialText;

	public StateInformation(bool flyPermission,bool movePermission,bool gatherPermission,bool pickUpPermission,bool objectPermission,
	bool talkPermissionTartaruga1,bool talkPermissionTartaruga2,bool talkPermissionUmano,bool talkPermissionCapitano,int loadDialogueTartaruga1,int loadDialogueTartaruga2,
	 bool spawnTartaruga1, bool spawnTartaruga2, string tutorialText)
	{
		this.flyPermission = flyPermission;
		this.movePermission = movePermission;
		this.gatherPermission = gatherPermission;
		this.pickUpPermission = pickUpPermission;
		this.objectPermission = objectPermission;
		this.talkPermissionTartaruga1 = talkPermissionTartaruga1;
		this.talkPermissionTartaruga2 = talkPermissionTartaruga2;
		this.talkPermissionUmano = talkPermissionUmano;
		this.talkPermissionCapitano = talkPermissionCapitano;
		this.loadDialogueTartaruga1 = loadDialogueTartaruga1;
		this.loadDialogueTartaruga2 = loadDialogueTartaruga2;
		this.spawnTartaruga1 = spawnTartaruga1;
		this.spawnTartaruga2 = spawnTartaruga2;
		this.tutorialText=tutorialText;
	}

	public override string ToString()
	{
		return("flyPermission=" + this.flyPermission + "" + "movePermission=" + this.movePermission +
			"" + "gatherPermission=" + this.gatherPermission + "" + "pickUpPermission=" + this.pickUpPermission + "" +
			"objectPermission=" + this.objectPermission + "" + "talkPermissionTartaruga1=" + this.talkPermissionTartaruga1 + "" +
			"talkPermissionTartaruga2=" + this.talkPermissionTartaruga2+ "" + "spawnTartaruga1=" + this.spawnTartaruga1+ "" +
			"spawnTartaruga2=" + this.spawnTartaruga2 + "" + "tutorialText" + this.tutorialText);

	}
}
