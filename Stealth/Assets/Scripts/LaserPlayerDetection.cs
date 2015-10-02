using UnityEngine;
using System.Collections;

public class LaserPlayerDetection : MonoBehaviour {
	
	private GameObject player; //player to be detected
	
	private LastPlayerSighting lastPlayerSighting; //game Controller
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag (Tags.player);
		lastPlayerSighting = GameObject.FindWithTag (Tags.gameController).GetComponent<LastPlayerSighting>();
	}
	
	void OnTriggerStay (Collider other) {
		if (GetComponent<Renderer>().enabled) {
			if (other.gameObject == player) {
				// ... set the last global sighting of the player to the colliding object's position.
				lastPlayerSighting.position = other.transform.position;

			}
		}

	}
}
