using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
	public GameObject text;
	public GameObject sun;

	int count = 0;
	bool direction = false;

	void Start () {
		
	}

	/*IEnumerator changeSize(){
		if (!direction && count != 20) {
			text.transform.localScale += new Vector3 (.01f, .01f, 0);
			count++;
		}
		if (count == 20) {
			direction = true;
		}
		if (count == 0) {
			direction = false;
		}
		if(direction && count != 0) {
			count--;
			text.transform.localScale -= new Vector3 (.01f, .01f, 0);
		}
		yield return new WaitForSeconds (50.0f);
	}*/

	void Update () {
		//StartCoroutine (changeSize ());	
	}
}
