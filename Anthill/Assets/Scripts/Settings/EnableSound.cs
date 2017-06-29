using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSound : MonoBehaviour {
	private CircleCollider2D enableSound;
	public GameObject disableSound;

	void Start () {
		enableSound = GetComponent<CircleCollider2D> ();	
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (enableSound.OverlapPoint (Camera.main.ScreenToWorldPoint (Input.mousePosition))){
				gameObject.SetActive (false);
				disableSound.SetActive (true);
			}
		}
	}
}
