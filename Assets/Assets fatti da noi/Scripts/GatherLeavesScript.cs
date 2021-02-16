using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherLeavesScript : MonoBehaviour
{
	GatherLeavesManagerScript gatherLeavesManager;

	private void Start()
	{
		gatherLeavesManager = FindObjectOfType<GatherLeavesManagerScript>();	
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && gatherLeavesManager._gatherPermission!=false)
		{
			
			GatherLeavesManagerScript.countLeaves = GatherLeavesManagerScript.countLeaves + 1;
			Object.Destroy(this.gameObject);
		}
	}


}
