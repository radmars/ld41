using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scene;

public class PressEnter : MonoBehaviour {

	public Scene nextScene;

	void Start () {
		
	}

	void Update () {
		Application.LoadScene(nextScene);
	}
}
