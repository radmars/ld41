using System.Collections;
using System.Linq;
using UnityEngine;

public class DamagePulse : MonoBehaviour {
	public float damageEverySeconds;
	public new CircleCollider2D collider;
	public int damage = 15;

	void Awake() {
		collider = GetComponent<CircleCollider2D>();
		StartCoroutine(DoDamage());
	}

	IEnumerator DoDamage() {
		while(true) {
			yield return new WaitForSeconds(damageEverySeconds);

			var hits = Physics2D.OverlapCircleAll(transform.position, collider.radius)
				.Where(h => h.gameObject.tag == "ball")
				.Select(h => h.gameObject)
				.ToArray();

			foreach(var h in hits) {
				h.GetComponent<Ball>().TakeDamage(damage);
			}
		}
	}
}
