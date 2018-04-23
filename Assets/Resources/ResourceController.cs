using UnityEngine;
using UnityEngine.UI;

public class ResourceController : MonoBehaviour {

	public static ResourceController instance;
	public Text resourceDisplay;

	public AudioSource mineralPickup;
	public AudioSource gasPickup;

	private string formatString = "WAVE     => {0}\nGAS      => {1}\nMINERALS => {2}\n";

	void Start() {
		instance = this;
		UpdateText();
	}

	private void UpdateText() {
		if(resourceDisplay) {
			resourceDisplay.text = string.Format(formatString, 1, Gas, Minerals);
		}
	}

	private int minerals;
	public int Minerals {
		get {
			return minerals;
		}
		set {
			mineralPickup.Play();
			minerals = value;
			UpdateText();
		}
	}

	private int gas;
	public int Gas {
		get {
			return gas;
		}
		set {
			gasPickup.Play();
			gas = value;
			UpdateText();
		}
	}

}
