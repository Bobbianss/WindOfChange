using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueContentManagerScript : MonoBehaviour
{
	public static void changeDialogue(GameObject npc, TextAsset txt)
	{
		npc.GetComponent<NPCTalkScript>().dialogueFile = txt;
	}
}
