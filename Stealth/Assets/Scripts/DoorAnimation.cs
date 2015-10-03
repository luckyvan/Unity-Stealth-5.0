using UnityEngine;
using System.Collections;

public class DoorAnimation : MonoBehaviour {

	public bool requireKey;

	public AudioClip doorSwitchClip;   // open or close door audio

	public AudioClip accessDeniedClip;

	private Animator anim;

	private GameObject player;

	private HashIDs hash;

	private PlayerInventory playerInventory;

	private AudioSource audioSource;

	private int count;

	void Awake () {
		anim = GetComponent<Animator>();

		hash = GameObject.FindWithTag (Tags.gameController).GetComponent<HashIDs>();

		player = GameObject.FindWithTag (Tags.player);

		playerInventory = player.GetComponent<PlayerInventory>();

		audioSource = GetComponent<AudioSource>();

		count = 0;
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject == player) {
			if (requireKey) {
				if (playerInventory.hasKey) {
					count++;
				}else{
					audioSource.clip = accessDeniedClip;
					audioSource.Play ();
				}
			}else{
				count++;
			}
		}
	}

	void OnTriggerExit (Collider other){
		if (other.gameObject == player) {
			count = Mathf.Max (0, count - 1);
		}
	}

	// Update is called once per frame
	void Update () {
		anim.SetBool(hash.openBool, count > 0);
		if (anim.IsInTransition (0) && !audioSource.isPlaying) {
			audioSource.clip = doorSwitchClip;
			audioSource.Play ();
		}
	}
}
