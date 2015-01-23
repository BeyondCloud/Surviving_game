using UnityEngine;
public class MovementProtoType: MonoBehaviour
{
	public float speed = 6f;


	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;
	Vector3 direction;
	Vector3 floorHitPoint;
	public Rigidbody arrowPrefab;
	public float arrowHeight;
    void Awake()
	{

		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();

	}
	void Update()
	{
		if(Input.GetMouseButtonDown(0)){
			anim.SetBool("IsWalking",true);
			Turning();
			StartMove();
		}
	}
	void FixedUpdate()
	{




		if(Mathf.Sign(direction.x) == Mathf.Sign(transform.position.x - floorHitPoint.x)
		   &&Mathf.Sign(direction.z) == Mathf.Sign(transform.position.z - floorHitPoint.z) )
		  
		{
			playerRigidbody.velocity = Vector3.zero;
			anim.SetBool("IsWalking",false);
			direction = Vector3.zero;

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

			//create an obj at where you point
			Rigidbody arrowInstance;
			Vector3 arrowInitialPoint = new Vector3 (floorHitPoint.x , floorHitPoint.y + arrowHeight , floorHitPoint.z); 
			arrowInstance = Instantiate(arrowPrefab,arrowInitialPoint,transform.rotation) as Rigidbody;
			arrowInstance.collider.enabled = false;
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
