using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour {
	private CircleCollider2D reload;
	public GameObject game;

	void Start () {
		reload = GetComponent<CircleCollider2D> ();	
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if(reload.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition))){
				game.SendMessage ("Reload");
				GameObject.Find ("Play").SendMessage ("quitPausedMenu");
			}
		}
	}
}
