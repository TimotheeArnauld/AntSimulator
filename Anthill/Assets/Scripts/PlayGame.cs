using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour {
	private CircleCollider2D play;
	public Image black;
	public Animator anim;

	void Start () {
		play = GetComponent<CircleCollider2D> ();	
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (play.OverlapPoint (Camera.main.ScreenToWorldPoint(Input.mousePosition))) {
				StartCoroutine (Fading ());
			}
		}
	}

	IEnumerator Fading(){
		anim.SetBool ("fade", true);
		yield return new WaitUntil (() => black.color.a == 1);
		SceneManager.LoadScene ("Anthill", LoadSceneMode.Single);
	}
}
