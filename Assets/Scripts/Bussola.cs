using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bussola : MonoBehaviour
{
	public Camera cam, overlayCam;
	private Transform playerTransform;
	public Transform[] objectives;
	public Transform fondoBussola, agoBussola;
	public Vector3 angle1, angle2, angle3, angle4, startEuler;
	private static int _compassState = 0;

	private void Start()
	{
		startEuler = transform.rotation.eulerAngles;
		playerTransform = FindObjectOfType<PlayerMovement>().transform;
	}


	void Update()
	{
		Vector3 ObjectiveDirectionInWorld = playerTransform.position - objectives[GameState.StateNumber].position;
		Vector3 ObjectiveDirectionFlat = Vector3.ProjectOnPlane(ObjectiveDirectionInWorld, Vector3.up);
		Vector3 LookDirectionWorldFlat = Vector3.ProjectOnPlane(cam.transform.forward, Vector3.up);
		Vector3 North = Vector3.forward;
		float angleFromNorthToLook = Vector3.SignedAngle(North, LookDirectionWorldFlat, Vector3.up);
		float angleFromNorthToObjDir = Vector3.SignedAngle(North, ObjectiveDirectionFlat, Vector3.up);
		fondoBussola.transform.localRotation = Quaternion.Euler(angle1 * angleFromNorthToLook + angle2 * angleFromNorthToObjDir);
		agoBussola.transform.localRotation = Quaternion.Euler(angle3 * angleFromNorthToLook + angle4 * angleFromNorthToObjDir);

	}	
}
