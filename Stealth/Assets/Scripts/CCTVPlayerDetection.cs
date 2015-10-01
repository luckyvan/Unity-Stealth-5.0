using UnityEngine;
using System.Collections;

public class CCTVPlayerDetection : MonoBehaviour {

	private GameObject player; //player to be detected

	private LastPlayerSighting lastPlayerSighting; //game Controller

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag (Tags.player);

		lastPlayerSighting = GameObject.FindWithTag (Tags.gameController).GetComponent<LastPlayerSighting>();
	}
	
	void OnTriggerStay (Collider other) {
		if (other.gameObject == player) {
			//determin whether player is in the light view
			Vector3 relPlayerPosition = player.transform.position - transform.position;
			RaycastHit hit;

			if (Physics.Raycast(transform.position, relPlayerPosition, out hit)) {
				if (hit.collider.gameObject == player) {
					//alarm on
					lastPlayerSighting.position = player.transform.position;
				}
			}
		}
	}
}
