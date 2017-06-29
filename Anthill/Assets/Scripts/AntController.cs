using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AntClass;
using UnityEngine.UI;

public class AntController : MonoBehaviour {
	private enum direction{UP, DOWN, LEFT, RIGHT};
	private Animator animator;
	private BoxCollider2D collider;
	private float speed = 0.05f;
	public Ant properties { get; set; }
	GameObject antNameObject;
	Text AntName;

	void Start () {
		animator = this.GetComponent<Animator> ();
		collider = this.GetComponent<BoxCollider2D> ();
		antNameObject = GameObject.FindGameObjectWithTag ("AntName");
		AntName = antNameObject.GetComponent<Text> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (collider.OverlapPoint (Camera.main.ScreenToWorldPoint (Input.mousePosition))) {
				AntName.text = properties.name;
			}
		}
	}
	public void move(int dir){
		animator.SetInteger ("Direction", dir);
		animator.enabled = true;
	}
}
