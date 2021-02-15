using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollect : MonoBehaviour
{
	public bool _objectCollectPermission;

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player" && _objectCollectPermission)
		{
			GameState.AdvanceState();
		}
	}

}
