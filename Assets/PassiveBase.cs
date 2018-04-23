using System.Collections;
using System.Linq;
using UnityEngine;

public abstract class PassiveBase: MonoBehaviour {
	public float downtimeSeconds = 2f;
	private Sprite original;
	public Sprite readySprite;
	public float radius = 2.5f;
	private new SpriteRenderer renderer;

	private void Awake() {
		renderer = GetComponent<SpriteRenderer>();
		original = renderer.sprite;
		StartCoroutine(MainLoop());
	}

	abstract protected IEnumerator ApplyPassive();

	private IEnumerator MainLoop() {
		while(true) {
			renderer.sprite = original;
			yield return new WaitForSeconds(downtimeSeconds);
			renderer.sprite = readySprite;
			yield return new WaitForSeconds(0.1f);
			yield return ApplyPassive();
		}
	}
}
