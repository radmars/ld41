using UnityEngine;

public class BuildOption : MonoBehaviour {

	public GameObject buildPrefab;
	private BuildSpot spot;
	private bool over;

	public void SetBuildSpot(BuildSpot s) {
		spot = s;
	}

	public void OnMouseEnter() {
		over = true;
	}

	public void OnMouseExit() {
		over = false;
	}

	public void OnMouseDown() {
		if(over) {
			spot.Build(Instantiate(buildPrefab));
		}
	}
}
