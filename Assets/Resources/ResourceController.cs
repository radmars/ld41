using UnityEngine;
using UnityEngine.UI;

public class ResourceController : MonoBehaviour {

	public static ResourceController instance;
	public Text resourceDisplay;

	public AudioSource mineralPickup;
	public AudioSource gasPickup;

	public AudioSource deathSound;

	public Plunger plunger;

	private int wave = 0;
	private int ballsLeftToKillThisWave = 0;

	private string formatString =
		"BASE HP  => {0}\n" +
		"WAVE     => {1}\n" +
		"GAS      => {2}\n" +
		"MINERALS => {3}\n" +
		"SCORE    => {4}\n";

	private string debugFormat = "base {0} wave {1} gas {2} minerals {3} score {4}";

	void Start() {
		instance = this;
		nextWave();
		UpdateText();
	}

	private int getNumBallsForWave() {
		return wave / 3 + 1;
	}

	private void UpdateText() {
		string text = string.Format(formatString, BaseHP, wave, Gas, Minerals, Score);
		if(resourceDisplay) {
			resourceDisplay.text = text;
		}
		Debug.Log(string.Format(debugFormat, BaseHP, wave, Gas, Minerals, Score));
	}

	private void nextWave() {
		wave++;
		ballsLeftToKillThisWave = getNumBallsForWave();
		plunger.SpawnThisManyBalls(ballsLeftToKillThisWave);
		UpdateText();
	}

	public void BallDied() {
		deathSound.Play();
		score += 1000;
		UpdateText();

		ballsLeftToKillThisWave--;
		if (ballsLeftToKillThisWave == 0) {
			nextWave();
		}
	}

	public void BallDrained() {
		BaseHP--;
		// Note that BallDrain currently relaunches the same ball
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
