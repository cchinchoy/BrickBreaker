using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bricks : MonoBehaviour {

	private int timeHit;
	private LevelManager levelManager;
	private bool isBreakable;
	private Color brickColor;

	public Sprite[] hitSprites;
	public static int breakableCount;
	public GameObject smoke;


	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if(isBreakable){
			breakableCount++;
		}
		timeHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D collide){
		if(isBreakable){
			HandleHits();
			if(breakableCount <= 0){
				levelManager.BrickDestroyed();
			}
		}
	}

	void HandleHits(){
		timeHit++;
		int maxHit = hitSprites.Length + 1;

		if (timeHit >= maxHit) {
			breakableCount--;
			puffSmoke();
			Destroy (gameObject);
		} else {
			LoadSprite ();
		}
	}
	void puffSmoke(){
		brickColor = gameObject.GetComponent<SpriteRenderer>().color;
		smoke.particleSystem.startColor = brickColor;
		GameObject smokePuff = Instantiate(smoke,this.transform.position, Quaternion.identity) as GameObject;
		ParticleSystem parts = smoke.GetComponent<ParticleSystem>();
		float totalDuration = parts.duration + parts.startLifetime;
		Destroy (smokePuff, totalDuration);
	}

	void LoadSprite(){
		int spriteIndex = timeHit - 1;
			this.GetComponent<SpriteRenderer>().sprite =  hitSprites[spriteIndex];
	}
}
