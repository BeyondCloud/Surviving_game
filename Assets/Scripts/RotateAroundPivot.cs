using UnityEngine;
using System.Collections;

public class RotateAroundPivot : MonoBehaviour {


	public static bool isRotate;

	//this three parameters used to maintain the balance of camera
	public Transform target;
	public Transform targetRight;
	public Transform targetLeft;
	//this two parameter determine camera obrit speed
	public float horizontalSpeed = 50f;    
	public float verticalSpeed = 25f;
	private Vector3 orbitVerticalAxis;

	//this four parameters detect if current position of mouse has change while click right btn
	private float errorX;
	private float errorY;
	private float oldX;
	private float oldY;



	void FixedUpdate () {
		if(Input.GetMouseButton(1))
		{
		   isRotate = true;
		   orbitVerticalAxis = targetLeft.transform.position - targetRight.transform.position; 
		   errorX = Input.mousePosition.x - oldX;
		   errorY = Input.mousePosition.y - oldY;
		   transform.RotateAround(target.position, Vector3.up, horizontalSpeed * Time.deltaTime * errorX);
		   transform.RotateAround(target.position, orbitVerticalAxis, verticalSpeed * Time.deltaTime * errorY);

		}
		else
		    isRotate = false;
		oldX = Input.mousePosition.x;
		oldY = Input.mousePosition.y;

	  
	 

	}

}
