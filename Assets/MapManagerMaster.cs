using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManagerMaster : MonoBehaviour
{
	public bool _mapPermission;
	private bool mapInput;
	public bool mapState;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		mapState = GetComponent<Animator>().GetBool("Mappa su");

		GamePermissionsManager.MovePermission = !mapState;

		Debug.Log("permmesso movimento" + GamePermissionsManager.MovePermission);

		if (Input.GetKeyDown(KeyCode.M) && _mapPermission)
		{
			GetComponent<Animator>().SetBool("Mappa su", !mapState);

		}


		Debug.Log("Cursor visible: " + Cursor.visible + " |Cursor lock: " + Cursor.lockState);
    }

	
}
