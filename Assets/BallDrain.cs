﻿using UnityEngine;

public class BallTrap : MonoBehaviour {

	public GameObject spawner;

	public void OnCollisionEnter2D(Collision2D collision) {
		collision.gameObject.transform.position = spawner.transform.position;
		var body = collision.gameObject.GetComponent<Rigidbody2D>();
		body.velocity = UnityEngine.Vector2.zero;
		body.angularVelocity = 0;
	}

}
