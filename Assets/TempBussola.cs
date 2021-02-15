using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBussola : MonoBehaviour
{
	public Camera cam;

    // Update is called once per frame
    void Update()
    {
		transform.rotation = Quaternion.Euler(-cam.transform.rotation.eulerAngles);
    }
}
