using UnityEngine;

public class Shot : MonoBehaviour {

	public int damage = 1;

	public void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "ball") {
			var ball = collision.gameObject.GetComponent<Ball>();
			Debug.Log(damage);
			ball.TakeDamage(damage);
		}

		Destroy(gameObject);
	}
}
