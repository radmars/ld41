using System.Collections;
using System.Linq;
using UnityEngine;

public class DamagePulse : PassiveBase {
	public int damage = 15;
	public AudioSource damageSound;

	protected override IEnumerator ApplyPassive() {
		yield return new WaitUntil( () => {
			var hits = Physics2D.OverlapCircleAll(transform.position, radius)
				.Where(h => h.gameObject.tag == "ball")
				.Select(h => h.gameObject)
				.ToArray();

			foreach(var h in hits) {
				h.GetComponent<Ball>().TakeDamage(damage);
			}

			if (hits.Length > 0) {
				damageSound.Play();
			}

			return hits.Length > 0;
		});
	}
}
