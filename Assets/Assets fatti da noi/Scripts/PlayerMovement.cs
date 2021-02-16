using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    //generali
    public Camera cam;
    public Rigidbody gabbiano;
    public bool penalty = false;
	//PauseMenu pauseMenu;               //scollegato
	//private float viewSensitivity;     //scollegato

	//Permessi
	public bool _flyPermission;
	public bool _movePermission;
	//gestione terra-aria
	public bool isWalkingNotFlying;
	private bool canLand = true;
	public float landingHeight = 1f;
	public float groundingHeight = 1f;
	public float rayVertOffset = 1f;
	public float noLandingTime = 1f;
	//terra
	public float jumpForce = 100f;
    public float walkForce = 10f;
	public float backFinWalkForceFactor = 1f;
    //aria
    public GameObject backFin; //rigidbody che tiene il gabbiano dritto in volo
    public Vector3 dragBody;
    public float windInfluence = 1f;
    public float dragInfluence = 1f;
    public float gravity;
    public float dimPortanza;
    public float propulsion = 1000f;
    public float portanza;
    private Vector3 windTaken;
    //acqua                                    (mobbasta elementi)
    public float waterPush = 50f;
    public float waterPushTime = 2f;
    private float waterTimeSpentIn = 0f;
   
    void Start()
    {
       
        gabbiano = GetComponent<Rigidbody>();
        //feetOffset = gabbiano.GetComponent<Collider>().bounds.size.z/2;
    }

    private void Update() //usato per controllare quando saltare, quando camminare e quando volare
    {
		
		if (IsGrounded() && Input.GetKeyDown(KeyCode.Space) && isWalkingNotFlying && _flyPermission)
        {
            Jump();
			TakeOff();
			StartCoroutine(TurnOffLandingForSeconds(noLandingTime));
		}

		LandOnLowAltitude();
		//Debug.Log("Is grounded " + IsGrounded() + "  Is walking " + isWalkingNotFlying + "  Can fly " + canFly + "  Wind taken " + windTaken);
	}

    void FixedUpdate()
    {
		if (GamePermissionsManager.MovePermission)
		{
			if (isWalkingNotFlying)
			{
				WalkPhysics();
			}
			else
			{
				FlyPhysics();
			}
		}
		       
    }  //dove vengono applicate tutte le forze tranne quella di salto

    private void Jump() //applica la forza di salto
    {
        gabbiano.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private bool IsGrounded() //controlla se si sta toccando terra serve per saltare
    {
        Debug.DrawRay(				transform.position-(Vector3.up*rayVertOffset), -Vector3.up * groundingHeight, Color.black);
		return Physics.Raycast(		transform.position-(Vector3.up*rayVertOffset),-Vector3.up, groundingHeight);
    }

	private void LandOnLowAltitude() //controlla l'altezza del gabbiano per atterrare
	{
		if (canLand)
		{

			bool rayHasHit = Physics.Raycast(transform.position - (Vector3.up * rayVertOffset), -Vector3.up, out RaycastHit landingRay, landingHeight);
			Debug.DrawRay(transform.position - (Vector3.up * rayVertOffset), -Vector3.up * landingHeight, Color.cyan);

			if( (rayHasHit) && landingRay.collider.tag == "Terreno" )
			{
				Land();
			}
		}
	}

	private void Land() //fa atterrare il gabbiano
    {      
        gabbiano.useGravity = true;
        //backFin.SetActive(false); //spegne pinna caudale
        isWalkingNotFlying = true;
    }

    private void TakeOff() //serve davvero?
    {
        gabbiano.useGravity = false;
        isWalkingNotFlying = false;
    }

    private void WalkPhysics() //usa i controlli per far camminare il gabbiano con WASD
    {
		//backFin.GetComponent<Rigidbody>().isKinematic = true;
		//gabbiano.isKinematic = true;
		Vector3 forward = Vector3.ProjectOnPlane(cam.transform.forward, Vector3.up).normalized;   //proietta camera.forward e camera.right sul piano XZ, li normalizza.
        Vector3 right = Vector3.ProjectOnPlane(cam.transform.right, Vector3.up).normalized;
        Vector3 walkDir = forward * Input.GetAxis("Vertical") + right * Input.GetAxis("Horizontal");
		gabbiano.AddForce(walkForce * walkDir);//li usa per applicare forze proporzionali agli axis horizontal e vertical.
		backFin.GetComponent<Rigidbody>().AddForce(-1f * walkDir * walkForce * backFinWalkForceFactor);
		//gabbiano.MovePosition(gabbiano.position + walkDir * walkForce);
		//gabbiano.MoveRotation(Quaternion.LookRotation(walkDir, Vector3.up));
    } 

    private void FlyPhysics() //Quando si vola, questo metodo calcola la forza totale sul gabbiano.
    {
	
		Vector3 totalFlyForce = Vector3.zero;

        Vector3 flowVelocityG = -gabbiano.velocity + (windTaken * windInfluence); //https://en.wikipedia.org/wiki/Flow_velocity
        Vector3 flowVelocityL = gabbiano.transform.InverseTransformVector(flowVelocityG);
        Vector3 unsignedFlowVelocityL = new Vector3(Mathf.Abs(flowVelocityL.x), Mathf.Abs(flowVelocityL.y), Mathf.Abs(flowVelocityL.z));
        Vector3 dragForceL = Vector3.Scale(Vector3.Scale(flowVelocityL, unsignedFlowVelocityL), dragBody * dragInfluence);
        Vector3 dragForceG = gabbiano.transform.TransformVector(dragForceL);



        Vector3 verticalForce = Vector3.up * (portanza - dimPortanza - gravity);

        Vector3 forwardForce = Input.GetAxis("Fire1") * cam.transform.forward * propulsion;

        totalFlyForce = (dragForceG + verticalForce + forwardForce) * Time.fixedDeltaTime;

        gabbiano.AddForce(totalFlyForce);
    }

    private void OnTriggerEnter(Collider collision)  //aggiungi vento (AGGIUNGERE UNO SMOOTHING) ---- RILEVA QUANDO ATTERRARE E MEMORIZZA SE SI PUò DECOLLARE
    {
        if (collision.gameObject.GetComponent<Wind>())
        {
            windTaken = windTaken + collision.gameObject.GetComponent<Wind>().WindForce();
        }        
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Acqua")
        {
            waterTimeSpentIn += (Time.deltaTime / waterPushTime);
            gabbiano.AddForce(Vector3.up * Mathf.Pow(waterTimeSpentIn, 2) * waterPush);
        }
    }

    private void OnTriggerExit(Collider collision) //togli vento
    {
        if (collision.gameObject.GetComponent<Wind>())
        {
            windTaken = windTaken - collision.gameObject.GetComponent<Wind>().WindForce();
        }

        if (collision.gameObject.tag == "Acqua")
        {
            waterTimeSpentIn = 0;
        }

    }

	IEnumerator TurnOffLandingForSeconds(float time)
	{
		canLand = false;
		yield return new WaitForSeconds(time);
		canLand = true;
	}
}
