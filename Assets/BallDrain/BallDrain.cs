using UnityEngine;

public class BallDrain: MonoBehaviour {

	public Plunger spawner;

	public void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.tag == "ball") {
			spawner.Launch(collision.gameObject);
		}
	}
}
