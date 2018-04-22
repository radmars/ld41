using UnityEngine;

public class Flipper : MonoBehaviour {

	public enum SideEnum {
		Left,
		Right
	}

	public SideEnum side;
	public float flippiness = 5;
	private bool left;
	private string key;
	private Rigidbody2D body;
	private HingeJoint2D hinge;


	// Use this for initialization
	void Start () {
		left = side == SideEnum.Left;
		key = left ? "Left" : "Right";
		body = GetComponent<Rigidbody2D>();
		hinge = GetComponent<HingeJoint2D>();
		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Walls"), LayerMask.NameToLayer("Flippers"), true);
		hinge.useMotor = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis(key) > 0) {
			hinge.useMotor = false;
			body.AddTorque((left ? 1 : -1) * flippiness, ForceMode2D.Impulse);
		}
		else {
			hinge.useMotor = true;
		}
	}
}
