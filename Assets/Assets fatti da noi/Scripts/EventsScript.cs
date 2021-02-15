using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsScript : MonoBehaviour
{   //Int32.Parse(input)
	public TextAsset eventFile;

	//variabili
	List<StateInformation> stateInformation;
	string[] linesFile;

	void Start()
	{
		stateInformation = new List<StateInformation>();
		linesFile = eventFile.text.Split("\n"[0]);
		
		foreach (string str in linesFile)
		{
			string[] vecTemp = str.Split('#');

			stateInformation.Add(new StateInformation(numberInBool(Int32.Parse(vecTemp[0])),numberInBool(Int32.Parse(vecTemp[1])),
				numberInBool(Int32.Parse(vecTemp[2])),numberInBool(Int32.Parse(vecTemp[3])),numberInBool(Int32.Parse(vecTemp[4])),
				numberInBool(Int32.Parse(vecTemp[5])),numberInBool(Int32.Parse(vecTemp[6])),numberInBool(Int32.Parse(vecTemp[7])),
				numberInBool(Int32.Parse(vecTemp[8])),Int32.Parse(vecTemp[9]), Int32.Parse(vecTemp[10]),numberInBool(Int32.Parse(vecTemp[11])),
				numberInBool(Int32.Parse(vecTemp[12])), vecTemp[13]));

		
		}

		Debug.Log(stateInformation[0].ToString());
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
