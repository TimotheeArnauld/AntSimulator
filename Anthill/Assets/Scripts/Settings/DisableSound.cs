using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSound : MonoBehaviour {
	private CircleCollider2D disableSound;
	public GameObject enableSound;

	void Start () {
		disableSound = GetComponent<CircleCollider2D> ();	
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (disableSound.OverlapPoint (Camera.main.ScreenToWorldPoint (Input.mousePosition))){
				gameObject.SetActive (false);
				enableSound.SetActive (true);
			}
		}
	}
}
