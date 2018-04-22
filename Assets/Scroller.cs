using UnityEngine;

public class Scroller : MonoBehaviour {

	public float scrollSpeed = 10;
	public float scrollArea = 100f;
	private Camera camera;
	public float min = 0;
	public float max = 5;

	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		var mY = Input.mousePosition.y;

		if (mY < scrollArea) {
			camera.transform.Translate(Vector3.up * -scrollSpeed * Time.deltaTime);
		}

		if (mY >= Screen.height - scrollArea) {
			camera.transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
		}

		camera.transform.position = new Vector3(
			camera.transform.position.x,
			Mathf.Clamp(camera.transform.position.y, min, max),
			camera.transform.position.z
		);
	}
}
