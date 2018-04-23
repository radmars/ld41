using System.Collections;
using System.Linq;
using UnityEngine;

public class DamagePulse : MonoBehaviour {
	public float damageEverySeconds;
	public int damage = 15;
	private Sprite original;
	public Sprite readySprite;
	public float radius = 2.5f;
	private new SpriteRenderer renderer;

	private void Awake() {
		StartCoroutine(DoDamage());
		renderer = GetComponent<SpriteRenderer>();
		original = renderer.sprite;
	}

	private IEnumerator DoDamage() {
		while(true) {
			yield return new WaitForSeconds(damageEverySeconds);
			renderer.sprite = readySprite;
			yield return new WaitForSeconds(0.1f);

			yield return new WaitUntil( () => {
				var hits = Physics2D.OverlapCircleAll(transform.position, radius)
					.Where(h => h.gameObject.tag == "ball")
					.Select(h => h.gameObject)
					.ToArray();

				foreach(var h in hits) {
					h.GetComponent<Ball>().TakeDamage(damage);
				}

				if(hits.Length > 0) {
					renderer.sprite = original;
					return true;
				}
				return false;
			});
		}
	}
}
