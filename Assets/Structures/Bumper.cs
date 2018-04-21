using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour {
	public float force = 500.0f;

	public bool useOverrideVector = false;
	public Vector2 overrideVector;

	public void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "ball") {
			Vector2 forceVector;

			if (useOverrideVector) {
				forceVector = overrideVector * force;
			} else {
				Vector3 diff = collision.gameObject.transform.position - transform.position;
				diff.Normalize();
				forceVector = new Vector2(diff.x, diff.y);
				forceVector *= force;
			}

			collision.gameObject.GetComponent<Rigidbody2D>().AddForce(forceVector);
		}
	}
}
