using UnityEngine;

public class Ball : MonoBehaviour {
	public int startingHP;
	private int hp;

	public GameObject hpBar;
	private Vector3 hpBarOffset;

	public AudioSource hitSound;
	public AudioSource collisionSound;

	private float soundScalar = 2.75f;

	public void Awake() {
		hp = startingHP;
		hpBarOffset = transform.position - hpBar.transform.position;
	}

	public void TakeDamage(int damage) {
		hitSound.Play();
		hp -= damage;
		hpBar.transform.localScale = new Vector3(
			(float)hp / startingHP,
			hpBar.transform.localScale.y,
			hpBar.transform.localScale.z
		);
		if(hp <= 0) {
			Die();
		}
	}

	public void Die() {
		ResourceController.instance.BallDied();
		Destroy(transform.parent.gameObject);
	}

	public void Update() {
		hpBar.transform.position = transform.position - hpBarOffset;
	}

	public void OnCollisionEnter2D(Collision2D collision) {
		if (collisionSound != null && collision.relativeVelocity.magnitude > soundScalar) {
			collisionSound.volume = collision.relativeVelocity.magnitude / (soundScalar * 25.0f);
			collisionSound.Play();
		}
	}
}
