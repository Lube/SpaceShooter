using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount = 10;

	public float waveWait = 2.5f;
	public float spawnWait = 0.5f;
	public float startWait = 2f;

	public Text scoreText;
	private int score;
	public Text restartText;
	public Text gameOverText;

	private bool gameOver;
	private bool restart;

	void Update() {
		if (restart && (Input.GetKeyDown(KeyCode.R) || Input.touchCount > 0)) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds (startWait);

		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), 0, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;

				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}

			if (gameOver) {
				restartText.text = "Apreta la 'R' para volver a empezar";
				restart = true;
				break;
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	void Start () {
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";

		StartCoroutine (SpawnWaves ());
		score = 0;
		UpdateScore ();
	}

	public void AddScore(int newScore) {
		score = score + newScore;
		UpdateScore();
	}

	void UpdateScore () {
		scoreText.text = "Puntaje: " + score.ToString ();
	}

	public void GameOver() {
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
