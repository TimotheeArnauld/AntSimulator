using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour {
	public GameObject UIView;
	float mousexThreshold = 0.01f;
	float mouseyThreshold = 0.01f;
	private float speed = 0.25f;
	private bool isBlocked = false;

	void Start () {
		
	}

	void Update () {
		if(!isBlocked){
			moveCamera ();
		}
	}

	void moveCamera(){
		float mousex = - Input.GetAxis ("Mouse X");
		float mousey = - Input.GetAxis ("Mouse Y");

		if (mousex > mousexThreshold){
			if (gameObject.transform.position.x < 20.5f) {
				gameObject.transform.Translate (speed, 0, 0);
				UIView.transform.Translate (speed, 0, 0);
			}
		}
		else if (mousex < -mousexThreshold){
			if (gameObject.transform.position.x > -19.4f) {
				gameObject.transform.Translate (-speed, 0, 0);
				UIView.transform.Translate (-speed, 0, 0);
			}
		}
		if (mousey > mouseyThreshold){
			if (gameObject.transform.position.y < 12.4f) {
				gameObject.transform.Translate (0, speed, 0);
				UIView.transform.Translate (0, speed, 0);
			}
		}
		else if (mousey < -mouseyThreshold){
			if (gameObject.transform.position.y > -12.8f) {
				gameObject.transform.Translate (0, -speed, 0);
				UIView.transform.Translate (0, -speed, 0);
			}
		}
	}

	public void BlockFreeMove(bool status){
		isBlocked = status;
		print (isBlocked);
	}
}
