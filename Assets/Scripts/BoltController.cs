using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour {
	public float speed = 1.0f;

	private Rigidbody rb;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}
}
