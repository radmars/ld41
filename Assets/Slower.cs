using System.Collections;
using System.Linq;
using UnityEngine;

public class Slower : PassiveBase {
	public float slowFactor = .25f;

	protected override IEnumerator ApplyPassive() {
		yield return new WaitUntil( () => {
			var hits = Physics2D.OverlapCircleAll(transform.position, radius)
				.Where(h => h.gameObject.tag == "ball")
				.Select(h => h.gameObject)
				.ToArray();

			foreach(var h in hits) {
				h.GetComponent<Rigidbody2D>().velocity *= slowFactor;
			}

			return hits.Length > 0;
		});
	}
}
