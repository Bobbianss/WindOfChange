using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManagerMaster : MonoBehaviour
{
	public bool _mapPermission;
	private bool mapInput;
	public bool mapIsUp;
	public Camera OverlayCam;
	public SkinnedMeshRenderer lastActive, noSelection;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		mapIsUp = GetComponent<Animator>().GetBool("Mappa su");

		GamePermissionsManager.MovePermission = !mapIsUp;

		if (Input.GetKeyDown(KeyCode.M) && _mapPermission)
		{
			GetComponent<Animator>().SetBool("Mappa su", !mapIsUp);
		}

		MapInteraction();

		Debug.Log("Cursor visible: " + Cursor.visible + " |Cursor lock: " + Cursor.lockState);
    }

	private void MapInteraction()
	{
		if (mapIsUp)
		{
			Ray mapRay = OverlayCam.ScreenPointToRay((Input.mousePosition));
			RaycastHit mapRayCastHit;
			Physics.Raycast(mapRay, out mapRayCastHit);
			if (mapRayCastHit.collider.tag == "Map")
			{
				lastActive = mapRayCastHit.collider.GetComponentInChildren<SkinnedMeshRenderer>();
				lastActive.enabled = true;
				noSelection.enabled = false;
			}
			else
			{
				noSelection.enabled = true;
				if (lastActive != null)
				{
					lastActive.enabled = false;
					lastActive = null;
					
				}
			}
		}
	}
}
