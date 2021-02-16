using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBussola : MonoBehaviour
{
	public Camera cam;
	public Transform playerTransform, objectiveTransform;
	public Transform fondoBussola, agoBussola;

	public Vector3 angle1, angle2, angle3, angle4;

    void Update()
    {
		Vector3 ObjectiveDirectionInWorld = playerTransform.position - objectiveTransform.position;
		Vector3 ObjectiveDirectionFlat = Vector3.ProjectOnPlane(ObjectiveDirectionInWorld, Vector3.up);
		Vector3 LookDirectionWorldFlat = Vector3.ProjectOnPlane(cam.transform.forward, Vector3.up);
		Vector3 North = Vector3.forward;
		float angleFromNorthToLook = Vector3.SignedAngle(North, LookDirectionWorldFlat, Vector3.up);
		float angleFromNorthToObjDir = Vector3.SignedAngle(North, ObjectiveDirectionFlat, Vector3.up);
		fondoBussola.transform.rotation = Quaternion.Euler(angle1* angleFromNorthToLook + angle2*angleFromNorthToObjDir - Vector3.up*90);
		agoBussola.transform.rotation = Quaternion.Euler(angle3 * angleFromNorthToLook + angle4 * angleFromNorthToObjDir + Vector3.forward * 90);

	}
}
