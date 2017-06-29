using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitPaused : MonoBehaviour {
	public GameObject controls;
	public GameObject paused;
	public GameObject pauseButton;

	private CircleCollider2D play;

	void Start () {
		play = GetComponent<CircleCollider2D> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (play.OverlapPoint (Camera.main.ScreenToWorldPoint (Input.mousePosition))) {
				quitPausedMenu ();
			}
		}
	}

	void quitPausedMenu(){
		controls.SetActive (true);
		paused.SetActive (false);
		pauseButton.SendMessage ("ChangeStatus", true);
	}
}
