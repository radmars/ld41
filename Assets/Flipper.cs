using UnityEngine;

public class Flipper : MonoBehaviour {

	public enum SideEnum {
		Left,
		Right
	}

	public SideEnum side;
	private string key;
	private Rigidbody2D body;


	// Use this for initialization
	void Start () {
		key = side == SideEnum.Left ? "Left" : "Right";
		body = GetComponentInChildren<Rigidbody2D>();
		Debug.Log(body);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis(key) > 0) {
			body.AddTorque(10f, ForceMode2D.Impulse);
			Debug.Log("Adding some troque");
		}
	}
}
