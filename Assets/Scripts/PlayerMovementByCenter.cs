using UnityEngine;
public class PlayerMovementByCenter: MonoBehaviour
{
	public float speed = 6f;
	
	
	Animator anim;
	Rigidbody playerRigidbody;
	Vector3 direction;
	Vector2  screenCenter;
	public Camera mainCam;
	void Awake()
	{


		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
		screenCenter.x = mainCam.pixelWidth/2;
		screenCenter.y = mainCam.pixelHeight/2;

	}
	void Update()
	{

		if(Input.GetMouseButtonDown(0))
			anim.SetBool("IsWalking",true);
		if(Input.GetMouseButton(0))
		{
			Turning();
			Move();
		}
		else
			anim.SetBool("IsWalking",false);
		if(RotateAroundPivot.isRotate)
		{
			Quaternion.LookRotation(mainCam.transform.position,Vector3.up);
		}
	}
	void OnMouseDown()
	{
		Debug.Log("aaaaa");
	}
	void Move()
	{
		direction.x = Input.mousePosition.x - screenCenter.x;
		direction.z = Input.mousePosition.y - screenCenter.y;

		direction = direction * speed * Time.deltaTime;   //normalize means "set vector3 as unit vector"
		playerRigidbody.MovePosition (transform.position + direction);
	}
	
	void Turning()
	{
		Quaternion newRotation = Quaternion.LookRotation(-direction);
		playerRigidbody.MoveRotation(newRotation);

	}
	
	
}
