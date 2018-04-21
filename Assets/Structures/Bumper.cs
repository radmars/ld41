using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour {
	public float force = 500.0f;

	public void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "ball") {
			Vector3 diff = collision.gameObject.transform.position - transform.position;
			diff.Normalize();
			Vector2 forceVector = new Vector2(diff.x, diff.y);
			forceVector *= force;
			collision.gameObject.GetComponent<Rigidbody2D>().AddForce(forceVector);
		}
	}
}
