using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour {
	private CircleCollider2D menu;

	void Start () {
		menu = GetComponent<CircleCollider2D> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (menu.OverlapPoint (Camera.main.ScreenToWorldPoint(Input.mousePosition))) {
				SceneManager.LoadScene("Menu", LoadSceneMode.Single);
			}
		}	
	}
}
