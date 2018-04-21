using UnityEngine;

public class BallDrain: MonoBehaviour {

	public GameObject spawner;

	public void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.tag == "ball") {
			collision.gameObject.transform.position = spawner.transform.position;
			var body = collision.gameObject.GetComponent<Rigidbody2D>();
			body.velocity = UnityEngine.Vector2.zero;
			body.angularVelocity = 0;
		}
	}
}
