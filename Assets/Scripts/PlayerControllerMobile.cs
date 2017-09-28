using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoundariesMobile {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerControllerMobile : MonoBehaviour {
	private Rigidbody rb;

	public float tilt;
	public int speed;
	public Boundaries boundary;

	public GameObject bolt;
	public Transform boltSpawn;

	public float fireDelta = 0.5F;
	private float nextFire = 0.5F;
	private float myTime = 0.0F;
	private GameObject newProjectile;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
	}

	void Update () {
		myTime = myTime + Time.deltaTime;

		if (Input.touchCount > 0 && myTime > nextFire) {
			Instantiate(bolt, boltSpawn.position, boltSpawn.rotation);
			nextFire = fireDelta;
			myTime = 0.0F;
			gameObject.GetComponent<AudioSource> ().Play ();
		}
	}

	void FixedUpdate () {
		float moveHorizontal = Input.acceleration.x;
		float moveVertical = Input.acceleration.y;


		rb.velocity = new Vector3 (moveHorizontal * speed, 0.0f, moveVertical * speed);
		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			0,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0, 0, rb.velocity.x * -tilt);
	}
}
