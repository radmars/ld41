using UnityEngine;

public class Flipper : MonoBehaviour {

	public enum SideEnum {
		Left,
		Right
	}

	public SideEnum side;
	private string key;

	// Use this for initialization
	void Start () {
		key = side == SideEnum.Left ? "Left" : "Right";
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(key)) {
		
		}
	}
}
