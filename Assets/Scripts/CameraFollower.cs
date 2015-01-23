using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {


	public Transform target;
	private Vector3 offset;

	public float smooth = 2;
	public float OrbitSpeed = 50f;


	void Start() {

		offset = transform.position - target.position; 
	}
	void FixedUpdate()
	{
		transform.LookAt(target);
		print(RotateAroundPivot.isRotate);

		offset  -= (offset * Input.GetAxis("Mouse ScrollWheel"));  //if you scroll the mouse,change slightly on distance

		if(RotateAroundPivot.isRotate)
		{
			offset= transform.position - target.position;

		}
		else
		   transform.position = Vector3.Lerp(transform.position ,target.position + offset  , Time.deltaTime *smooth) ;

		  
	}


}
