using UnityEngine;

public class BallDrain: MonoBehaviour {

	public Plunger spawner;

	public void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.tag == "ball") {
			ResourceController.instance.BallDrained();
			spawner.Launch(collision.gameObject);
		}
	}
}
