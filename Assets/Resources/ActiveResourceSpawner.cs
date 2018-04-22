using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveResourceSpawner : MonoBehaviour {

	public Resource resourceToSpawn;
	public int numResourcesToSpawn = 5;
	public float spawnRadius = 0.5f;
	public float pushForce = 50.0f;

	public void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "ball") {
			for (int i = 0; i < numResourcesToSpawn; i++) {
				Vector3 push = new Vector3(Random.Range(-spawnRadius, spawnRadius),
					Random.Range(-spawnRadius, spawnRadius), transform.position.z);
				Resource resource = Instantiate(resourceToSpawn, transform.position + push, transform.rotation);
				push.Normalize();
				Vector2 force = new Vector2(push.x, push.y);
				resource.GetComponent<Rigidbody2D>().AddForce(force * pushForce);
			}
		}
	}
}
