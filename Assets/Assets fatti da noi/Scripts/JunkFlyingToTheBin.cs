using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFlyingToTheBin : MonoBehaviour
{
	public Transform binTransform;
	public float throwTime = 1f;
	public float throwHeight = 2f;
	public bool throwJunk = false;
	private Vector3 junkPosition;
	private float normalizingDistance;


	void Update()
    {
		if (!throwJunk)
		{
			junkPosition = this.gameObject.transform.position;
			Vector3 relativePos = junkPosition - binTransform.position;
			normalizingDistance = Vector3.Magnitude(Vector3.Scale(relativePos, new Vector3(1f, 0f, 1f)));
		}

		if (throwJunk)
		{
			this.gameObject.transform.position += Vector3.Normalize(-this.gameObject.transform.position + binTransform.position) * (1f/throwTime) * Time.deltaTime;
			
			float horizDistance = Vector3.Magnitude(Vector3.Scale(this.gameObject.transform.position - binTransform.position, new Vector3(1f, 0f, 1f))) * Time.deltaTime;
			float parabulaVar = horizDistance / normalizingDistance; //0 quando parte, 1 quando arriva
			float parabula = ((4f * parabulaVar) - (4f * Mathf.Pow(parabulaVar,2f))) * throwHeight ; 
			this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y+parabula, this.gameObject.transform.position.z);
		}
		
    }

	public void TrashDestroy()
	{
		if (FindObjectOfType<JunkFlyingToTheBin>() == null) //funziona?
		{
			GameState.AdvanceState();
		}
		Destroy(this.gameObject,throwTime*2);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Cestino")
		{
			TrashDestroy();
		}
	}


}
