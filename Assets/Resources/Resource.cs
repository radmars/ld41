using UnityEngine;

public class Resource : MonoBehaviour {

	public enum ResourceType {
		Gas,
		Minerals,
	}
	public ResourceType type;

	public void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "ball") {
			Destroy(gameObject);

			if (type == ResourceType.Minerals) {
				ResourceController.instance.Minerals++;
			} else if (type == ResourceType.Gas) {
				ResourceController.instance.Gas++;
			}
		}
	}

}
