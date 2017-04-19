using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	float mousePosInBlocks;
	public bool autoPlay = false;
	private Ball ball;
	// Update is called once per frame
	void Start() {
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	void Update () {
		if (!autoPlay) {
			MoveWithMouse();
		}
		AutoPlay ();
	}
	void AutoPlay (){
		float coord = Screen.width / 16;
		Vector3 paddlePos = new Vector3 (0.5f, transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x, 0.5f, 15.5f);
		this.transform.position = paddlePos;
	}
	void MoveWithMouse (){
		float coord = Screen.width / 16;
		Vector3 mousePos = new Vector3 (0.5f, transform.position.y, 0f);
		mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16);
		mousePos.x = Mathf.Clamp (mousePosInBlocks, 0.5f, 15.5f);
		this.transform.position = mousePos;
	}
}
