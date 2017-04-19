using UnityEngine;
using System.Collections;

public class Music_Player : MonoBehaviour {
	static Music_Player instance = null;
	// Use this for initialization

	void Awake(){
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
}
