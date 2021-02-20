using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueContentManagerScript : MonoBehaviour
{
	public static GameObject tartaruga1;
	public static GameObject tartaruga2;
	public static GameObject marinaio;
	public static GameObject capitano;

	
	public void Awake()
	{
		tartaruga1 = GameObject.Find("Tartaruga_1");
		tartaruga2 = GameObject.Find("Tartaruga_2");
		marinaio = GameObject.Find("Umano");
		capitano = GameObject.Find("Capitano");

	}
	public static void ChangeDialogue(GameObject npc, TextAsset txt)
	{
		npc.GetComponent<NPCTalkScript>().changeDialogue(txt);
	}

	public static void UploadDialogue(int index, GameObject npc)
	{
		TextAsset textTemp = new TextAsset();
		//Debug.Log("sono dentro nell'indice " + index);
		textTemp = Resources.Load<TextAsset>("Dialoghi/" + index);
		ChangeDialogue(npc, textTemp);
		


		/*
		switch (index)
		{
			case 1:
				Debug.Log("sono dentro nel indice_" + index);
				textTemp = Resources.Load<TextAsset>("Dialoghi/1");
				changeDialogue(npc, textTemp);
				break;
			case 2:
				Debug.Log("sono dentro nel indice_" + index);
				textTemp = Resources.Load<TextAsset>("Dialoghi/2");
				
				break;
			case 3:
				Debug.Log("sono dentro nel indice_" + index);
				textTemp = Resources.Load<TextAsset>("Dialoghi/3");
				changeDialogue(npc, textTemp);
				break;
			case 4:
				Debug.Log("sono dentro nel indice_" + index);
				textTemp = Resources.Load<TextAsset>("Dialoghi/4");
				changeDialogue(npc, textTemp);
				break;
			case 5:
				Debug.Log("sono dentro nel indice_" + index);
				textTemp = Resources.Load<TextAsset>("Dialoghi/5");
				changeDialogue(npc, textTemp);
				break;
			case 6:
				Debug.Log("sono dentro nel indice_" + index);
				textTemp = Resources.Load<TextAsset>("Dialoghi/6");
				changeDialogue(npc, textTemp);
				break;
			case 7:
				Debug.Log("sono dentro nel indice_" + index);
				textTemp = Resources.Load<TextAsset>("Dialoghi/7");
				changeDialogue(npc, textTemp);
				break;
			case 8:
				Debug.Log("sono dentro nel indice_" + index);
				textTemp = Resources.Load<TextAsset>("Dialoghi/8");
				changeDialogue(npc, textTemp);
				break;
		}*/
	}
}
