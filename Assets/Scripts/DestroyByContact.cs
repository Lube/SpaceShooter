using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	private GameController gameManager;

	public int scoreValue;

	void Start () {
		GameObject gameManagerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameManagerObject != null) {
			gameManager = gameManagerObject.GetComponent<GameController> ();
		}

		if (gameManager == null) {
			Debug.Log ("No se pudo encontrar el Game Manager");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Boundary") {
			return;
		}

		if (other.gameObject.tag == "Player") {
			Instantiate (playerExplosion, transform.position, transform.rotation);
			gameManager.GameOver ();
		} else {
			Instantiate (explosion, transform.position, transform.rotation);
		}

		gameManager.AddScore (scoreValue);
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
