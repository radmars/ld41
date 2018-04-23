using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfieldController : MonoBehaviour {

	public static PlayfieldController instance;
	public AudioSource deathSound;

	void Start() {
		instance = this;
	}
}
