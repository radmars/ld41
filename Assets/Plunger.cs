using UnityEngine;

public class Plunger : MonoBehaviour {
	public void Launch(GameObject o) {
		o.transform.position = transform.position;
		var body = o.GetComponent<Rigidbody2D>();
		body.velocity = Vector2.zero;
		body.angularVelocity = 0;
		body.rotation = 0;
		body.velocity = Vector2.up * 20;
	}
}
