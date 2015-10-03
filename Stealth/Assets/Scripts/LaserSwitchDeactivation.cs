using UnityEngine;
using System.Collections;

public class LaserSwitchDeactivation : MonoBehaviour {

	public GameObject laser; //laser fense to be controlled by this Switch

	public Material unlockedMaterial;

	private GameObject player;

	private GameObject screen; //the screen to indicate whether the switch is locked or unlocked.

	private AudioSource audioSource;

	void Awake (){
	
		audioSource = GetComponent<AudioSource>();

		screen = transform.Find("prop_switchUnit_screen").gameObject;

		player = GameObject.FindWithTag(Tags.player);

	}

	void LaserDeactivation (){
		laser.SetActive(false);

		screen.GetComponent<Renderer>().material = unlockedMaterial;

		audioSource.Play ();
	}
	
	void OnTriggerStay (Collider other){
		if (other.gameObject == player) {
			if (Input.GetButton ("Switch")) {
				LaserDeactivation ();
			}
		}

	}
}
