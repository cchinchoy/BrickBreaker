using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddleToBallPos;
	private bool hasStarted = false;

	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallPos = this.transform.position - paddle.transform.position;
	}

	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallPos;
		}
			if (Input.GetMouseButton (0)) {
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2(2f, 15f);
		}
	}

	void OnCollisionEnter2D (Collision2D col){
		if(hasStarted == true){
			audio.Play();
		}
	}
}