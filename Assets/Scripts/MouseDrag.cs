using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour {

	float horizontal;
	float vertical;
	public Transform container;
	public float turnSpeedMouse = 2f;
	
	// Update is called once per frame
	void LateUpdate () {
		//using mouse
		if (Input.GetMouseButton(0)) {
			horizontal = Input.GetAxis ("Mouse X");
			vertical = Input.GetAxis ("Mouse Y");

			//This is made in order to avoid rotation on z, just by typing 0 on zcoord isn't enough
			//so the container is rotated around Y and the camera around X separately
			container.Rotate (new Vector3 (0, horizontal * (-1), 0) * Time.deltaTime * turnSpeedMouse); 
			transform.Rotate (new Vector3 (vertical, 0, 0) * Time.deltaTime * turnSpeedMouse); 
		}
	}


}
