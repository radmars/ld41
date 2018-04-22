using UnityEngine;

public class BuildSpot : MonoBehaviour {

	Color mouseOverColor = Color.red;
	Color originalColor;
	new SpriteRenderer renderer;

	private BuildOption[] options;
	private bool over;

	void Start()
	{
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Balls"), LayerMask.NameToLayer("BuildSpots"));
		renderer = GetComponent<SpriteRenderer>();
		originalColor = renderer.material.color;
		options = GetComponentsInChildren<BuildOption>(true);
		foreach(var o in options) {
			o.gameObject.SetActive(false);
			o.SetBuildSpot(this);
		}
	}

	public void OnMouseEnter() {
		over = true;
		renderer.material.color = mouseOverColor;
	}

	public void OnMouseDown() {
		if(over) {
			foreach(var o in options) {
				o.gameObject.SetActive(!o.gameObject.activeInHierarchy);
			}
		}
	}

	public void OnMouseExit() {
		over = false;
		renderer.material.color = originalColor;
	}

	public void Build(GameObject prefab) {
		prefab.transform.parent = transform.parent;
		prefab.transform.position = transform.position;
		Destroy(gameObject);
	}
}
