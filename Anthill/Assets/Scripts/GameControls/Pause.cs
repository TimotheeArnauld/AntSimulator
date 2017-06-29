using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
	private CircleCollider2D pause;
	public GameObject background;
	public GameObject controls;
	public GameObject camera;
	public GameObject game;

	private bool isPaused = false;

	void Start () {
		pause = GetComponent<CircleCollider2D> ();
	}

	IEnumerator onComposent(){
		pause.transform.localScale += new Vector3(0.1F, 0.1F, 0);
		yield return new WaitForSeconds (0.1f);
		pause.transform.localScale -= new Vector3(0.1F, 0.1F, 0);
	}

	void Update () {
		if (pause.OverlapPoint (Camera.main.ScreenToWorldPoint (Input.mousePosition))) {
			StartCoroutine (onComposent());
		}

		if (Input.GetMouseButtonDown (0)) {
			if (pause.OverlapPoint (Camera.main.ScreenToWorldPoint (Input.mousePosition))) {
				ChangeStatus (!pause);
			}
		}
	}

	private void ChangeStatus(bool status){
		if(!status){
			background.SetActive(true);
			isPaused = true;
			controls.SetActive (false);
			game.SendMessage ("displayTimer", false);
		}else{
			background.SetActive(false);
			isPaused = false;
			controls.SetActive (true);
			game.SendMessage ("displayTimer", true);
		}
		camera.SendMessage ("BlockFreeMove", isPaused);
	}
}
