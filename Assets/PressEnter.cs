using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressEnter : MonoBehaviour {

	private TextMesh textMesh;

	void Start () {
		textMesh = GetComponent<TextMesh>();
		StartCoroutine(BlinkText());
	}

	private IEnumerator BlinkText()
	{
		while(true)
		{
			textMesh.text = "";
			yield return new WaitForSeconds(.5f);
			textMesh.text = "PRESS ENTER";
			yield return new WaitForSeconds(.5f);
		}
	}

	void Update () {
		if(Input.anyKeyDown)
		{
			Debug.Log("HI");
			SceneManager.LoadScene("em-test");
		}
	}
}
