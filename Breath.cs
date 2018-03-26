using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breath : MonoBehaviour {
	
	//breath_out indicates how long until the player runs out of air
	private float breath_out;
	//breath_timer indicates how long the player has been underwater
	private float breath_timer;
	//private GameObject playerHealth;
	private bool isUnderwater;
	//Go into this script in the component window and add the player
	//  that is in the scene as the player field and it should work.
	public GameObject player = GameObject.FindGameObjectWithTag("Player");


	// Use this for initialization
	void Start () {
		breath_out = 10f;
		breath_timer = 0f;
		isUnderwater = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isUnderwater == true) {
			StopCoroutine(BreathCountDown (player));
			StartCoroutine(BreathCountDown (player));
		}
	}

	//ontriggerstay is called once per frame for each rigidbody or 
	//   collider that is within this rigidbody or collider.
	// used to indicate whether player is underwater.
	void OnTriggerEnter2D(Collider2D collisionInfo) {
		if (collisionInfo.gameObject.tag == "Player") {
			isUnderwater = true;
		}
		//breath_timer += 2f;

	}

	IEnumerator BreathCountDown(GameObject player){
		yield return new WaitForSeconds (2f);
		breath_timer = breath_timer + Time.deltaTime;
		if (breath_timer >= breath_out) {
			yield return new WaitForSeconds (2f);
			player.GetComponent<PlayerHealth>().takeDamage(1); 
			//StopCoroutine(BreathRanOut (player));
			//StartCoroutine(BreathRanOut (player));

		}
	}

	//Calls the takeDamage method from PlayerHealth
	//  every 2 seconds while breath has run out,
	//  dealing 1 damage out of 100 currently.
	//thePlayer is the Player that collided with the
	//  Water's Trigger, allowing the Player's
	//  PlayerHealth Script to be referenced.
	//IEnumerator BreathRanOut(GameObject player) {
		
	//}



	//ontriggerexit is called when a rigidbody or 
	//   collider gets out of this rigidbody or collider.
	// used to indicate whether player is above water.
	void OnTriggerExit2D(Collider2D collisionInfo) {
		if (collisionInfo.gameObject.tag == "Player") {
			breath_timer = 0f;
			isUnderwater = false;
			//StopCoroutine(BreathRanOut (collisionInfo));
			//breath_timer resets when going above water
			//  because the player takes in more air.
		}
		//breath_timer = 0f;
	}

	//Charlie's code below this point

	/*
	float timer = 0f;     
	float outOfBreathTime = 2f;     
	bool canIncrementTimer;
	GameObject player = GameObject.FindGameObjectWithTag("Player");
	void Update()     {         
		if (canIncrementTimer)         
		{             
			timer += Time.deltaTime;         
		}         
		if (player.rigidbody2D && (timer > outOfBreathTime))         
		{             
			timer = 0f;             
			canIncrementTimer = false;             
			StopCoroutine("DealDamage");             
			StartCoroutine("DealDamage");         
		}     
	}     
	IEnumerator DealDamage()
	{         
		if (player.isUnderWater) {             
			yield return new WaitForSeconds (1f);             
			player.gameObject.GetComponent<PlayerHealth>().takeDamage(50); 
		} 
		else {             
			yield return null;
			canIncrementTimer = true;
		}
	}
	*/

}
