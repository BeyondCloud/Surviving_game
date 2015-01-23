using UnityEngine;
using System.Collections;

public class AutoZoom : MonoBehaviour {
	
	
	public Transform target;
	private Vector3 middle;
	public float smooth = 2;
	private Vector3 offset;
	private Vector3 initialPosition;
	
	void Start() {
		offset = transform.position - target.position; 
		middle = (transform.position - target.position)/2;  
		initialPosition = transform.position;
	}
	void Update()
	{

		if(Input.GetMouseButton(0))
			transform.position = Vector3.Lerp(transform.position ,offset + target.position , Time.deltaTime *smooth) ;
		else
		    transform.position = Vector3.Lerp(transform.position ,middle + target.position, Time.deltaTime *smooth) ;
	}
	
	
}
