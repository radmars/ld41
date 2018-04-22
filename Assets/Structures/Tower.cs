using UnityEngine;

public class Tower : MonoBehaviour {

	public Shot shotPrefab;

	public int shootCooldownMax = 100;
	private int shootCooldown;
	public float maxTargetingDistance = 50.0f;
	public float shotForceMult = 100.0f;

	public float leadsTargetAmount = 0.3f;
	private float towerRadius;

	void Start() {
		shootCooldown = shootCooldownMax;
		towerRadius = GetComponent<CircleCollider2D>().radius;
	}
	
	// Update is called once per frame
	void Update () {
		shootCooldown--;
		if (shootCooldown <= 0) {
			findTargetAndShoot();
			shootCooldown = shootCooldownMax;
		}
	}

	private void findTargetAndShoot() {
		GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
		if (balls.Length == 0) {
			return;
		}

		GameObject target = null;
		float distance = Mathf.Infinity;
		var position = transform.position;
		var diff = new Vector3();
		foreach (var ball in balls) {
			diff = ball.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance && curDistance < maxTargetingDistance) {
				target = ball;
				distance = curDistance;
			}
		}

		if (target == null) {
			return;
		}

		var toTarget = new Vector2(diff.x, diff.y);
		toTarget += target.GetComponent<Rigidbody2D>().velocity * leadsTargetAmount;

		toTarget.Normalize();
		diff.Normalize();
		Vector3 shotPos = transform.position + (diff * (towerRadius + 0.2f));

		Shot shot = Instantiate(shotPrefab, shotPos, transform.rotation);
		shot.damage = 1;

		Vector2 shotForce = toTarget * shotForceMult;
		shot.GetComponent<Rigidbody2D>().AddForce(shotForce);
	}
}
