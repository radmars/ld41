using System.Collections;
using UnityEngine;

public class Plunger : MonoBehaviour {

	public GameObject ballPrefab;
	public float spawnRatePerSecond = 1;
	private int ballsToSpawn = 1;

	public AudioSource plungeSound;

	public void Start() {
		ballPrefab.SetActive(false);
	}

	public void SpawnThisManyBalls(int balls) {
		ballsToSpawn = balls;
		StartCoroutine(SpawnBalls());
	}

	private IEnumerator SpawnBalls() {
		float perSecond = 1f/spawnRatePerSecond;
		for (int i = 0; i < ballsToSpawn; i++) {
			yield return new WaitForSeconds(perSecond);
			if(ballPrefab != null) {
				var container = Instantiate(ballPrefab);
				container.SetActive(true);
				var ball = container.GetComponentInChildren<Ball>();
				Launch(ball.gameObject);
			}
		}
	}

	public void Launch(GameObject o) {
		o.transform.position = transform.position;
		var body = o.GetComponent<Rigidbody2D>();
		body.velocity = Vector2.zero;
		body.angularVelocity = 0;
		body.rotation = 0;
		body.velocity = Vector2.up * 20;

		plungeSound.Play();
	}
}
