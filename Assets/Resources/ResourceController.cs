using UnityEngine;
using UnityEngine.UI;

public class ResourceController : MonoBehaviour {

	public static ResourceController instance;
	public Text resourceDisplay;

	public AudioSource mineralPickup;
	public AudioSource gasPickup;

	public AudioSource deathSound;

	private int wave = 1;

	private string formatString =
		"BASE HP  => {0}\n" +
		"WAVE     => {1}\n" +
		"GAS      => {2}\n" +
		"MINERALS => {3}\n" +
		"SCORE    => {4}\n";

	void Start() {
		instance = this;
		UpdateText();
	}

	private void UpdateText() {
		string text = string.Format(formatString, BaseHP, wave, Gas, Minerals, Score);
		if(resourceDisplay) {
			resourceDisplay.text = text;
		}
		Debug.Log(text);
	}

	public void BallDied() {
		deathSound.Play();
		score += 1000;
		UpdateText();
	}

	public void BallDrained() {
		BaseHP--;
		UpdateText();
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

	private int score;
	public int Score {
		get {
			return score;
		}
		set {
			score = value;
		}
	}

	private int baseHP = 5;
	public int BaseHP {
		get {
			return baseHP;
		}
		set {
			baseHP = value;
			if (baseHP <= 0) {
				// GAME OVER???
			}
		}
	}

}
