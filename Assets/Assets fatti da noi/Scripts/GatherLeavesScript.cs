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
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player" && gatherLeavesManager._gatherPermission!=false)
		{
			Object.Destroy(this.gameObject);
			GatherLeavesManagerScript.countLeaves = GatherLeavesManagerScript.countLeaves + 1;
		}
	}


}
