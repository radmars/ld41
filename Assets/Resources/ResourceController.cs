using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour {

	public static ResourceController instance;

	void Start() {
		instance = this;
	}

	private int minerals;
	public int Minerals {
		get {
			return minerals;
		}
		set {
			minerals = value;
		}
	}

	private int gas;
	public int Gas {
		get {
			return gas;
		}
		set {
			gas = value;
		}
	}

}
