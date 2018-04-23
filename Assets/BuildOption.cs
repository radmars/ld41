using UnityEngine;

public class BuildOption : MonoBehaviour {

	public GameObject buildPrefab;
	private BuildSpot spot;
	private bool over;
	private TextMesh text;

	public int mineralCost = 10;
	public int gasCost = 20;

	public void SetBuildSpot(BuildSpot s) {
		spot = s;
	}

	public void OnMouseEnter() {
		over = true;
	}

	public void OnMouseExit() {
		over = false;
	}

	public void Awake() {
		text = GetComponentInChildren<TextMesh>();
	}

	public void Update() {
		text.text = string.Format("{0}M\n{1}G", mineralCost, gasCost);
		text.color = ResourceController.instance.Minerals >= mineralCost && ResourceController.instance.Gas >= gasCost ? Color.white : Color.red;
	}

	public void OnMouseDown() {
		if(over) {
			if(ResourceController.instance.Minerals >= mineralCost && ResourceController.instance.Gas >= gasCost) {
				ResourceController.instance.Minerals -= mineralCost;
				ResourceController.instance.Gas -= gasCost;
				spot.Build(Instantiate(buildPrefab));
			}
		}
	}
}
