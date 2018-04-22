using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {

	public string type;

	public void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "ball") {
			Destroy(gameObject);

			if (type == "minerals") {
				ResourceController.instance.Minerals++;
			} else if (type == "gas") {
				ResourceController.instance.Gas++;
			}
		}
	}

}
