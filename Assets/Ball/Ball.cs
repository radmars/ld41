using UnityEngine;

public class Ball : MonoBehaviour {
	public int startingHP;
	private int hp;

	public GameObject hpBar;
	private Vector3 hpBarOffset;

	public void Start() {
		hp = startingHP;
		hpBarOffset = transform.position - hpBar.transform.position;
	}

	public void TakeDamage(int damage) {
		hp -= damage;

		Debug.Log(damage);
		Debug.Log((float)hp / (float)startingHP);

		hpBar.transform.localScale = new Vector3(
			(float)hp / startingHP,
			hpBar.transform.localScale.y,
			hpBar.transform.localScale.z
		);
		Debug.Log(hpBar.transform.localScale);
		if(hp <= 0) {
			Die();
		}
	}

	public void Die() {
		Destroy(transform.parent);
	}

	public void Update() {
		hpBar.transform.position = transform.position - hpBarOffset;
	}
}
