using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;


	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;
	Vector3 direction;
	Vector3 floorHitPoint;
    void Awake()
	{

		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();

	}
	void FixedUpdate()
	{

		if(Input.GetMouseButtonDown(0)){
			anim.SetBool("IsWalking",true);
			    Turning();
				StartMove();
		}


		if(direction.x * (transform.position.x - floorHitPoint.x) >= 0 
		   && direction.z *(transform.position.z - floorHitPoint.z) >= 0
		   )
		  
		{
			anim.SetBool("IsWalking",false);
			Debug.Log ("Stop");
			direction = Vector3.zero;
			playerRigidbody.velocity = Vector3.zero;
		}
		Move ();

	}

	void StartMove()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		if(Physics.Raycast (camRay,out floorHit,camRayLength,floorMask))
		{
			direction =  floorHit.point - transform.position ;
			direction.y = 0;   //if you forget to set this , player will keep walking if you click you're self
			floorHitPoint = floorHit.point; 
		}


	}
	void Move()
	{   
		direction = direction.normalized * speed * Time.deltaTime;   //normalize means "set vector3 as unit vector"

		playerRigidbody.MovePosition (transform.position + direction);
	}
	void Turning()
	{

		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;

		if(Physics.Raycast (camRay,out floorHit,camRayLength,floorMask))
	    {

			Vector3 playerToMouse = -(floorHit.point - transform.position);
			playerToMouse.y = 0f;
			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);

		}

	}


}
