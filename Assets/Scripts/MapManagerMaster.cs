using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MapManagerMaster : MonoBehaviour
{
	public bool _mapPermission;
	private bool mapInput;
	public bool mapIsUp;
	public Camera OverlayCam;
	public SkinnedMeshRenderer noSelection;
	private SkinnedMeshRenderer lastActive;

	private string xAxisName, yAxisName;
	void Start()
    {
		xAxisName = FindObjectOfType<CinemachineFreeLook>().m_XAxis.m_InputAxisName;
		yAxisName = FindObjectOfType<CinemachineFreeLook>().m_YAxis.m_InputAxisName;
	}

    // Update is called once per frame
    void Update()
    {
		mapIsUp = GetComponent<Animator>().GetBool("Mappa su");

		GamePermissionsManager.MovePermission = !mapIsUp;

		if (Input.GetKeyDown(KeyCode.M) && _mapPermission)
		{
			mapIsUp = !mapIsUp;
			GetComponent<Animator>().SetBool("Mappa su", mapIsUp);
			Cursor.visible = mapIsUp;
			StopCameraWheLookingMap();
		}

		MapInteraction();

		//Debug.Log("Cursor visible: " + Cursor.visible + " |Cursor lock: " + Cursor.lockState);
    }

	private void StopCameraWheLookingMap()
	{
		FindObjectOfType<CinemachineFreeLook>().m_XAxis.m_InputAxisName = mapIsUp ? null : xAxisName;
		FindObjectOfType<CinemachineFreeLook>().m_YAxis.m_InputAxisName = mapIsUp ? null : yAxisName;
		FindObjectOfType<CinemachineFreeLook>().m_XAxis.m_InputAxisValue = 0f;
		FindObjectOfType<CinemachineFreeLook>().m_YAxis.m_InputAxisValue = 0f;
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
