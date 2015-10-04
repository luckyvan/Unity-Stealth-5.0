using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float health = 100f;

	public AudioClip deathClip;

	public float resetAfterDeath = 5f;

	private bool playerDead = false;

	private Animator anim;

	private HashIDs hash;

	private PlayerMovement playerMovement;

	private LastPlayerSighting gameController;

	private float timer = 0f;

	private ScreenFadeInOut sceneFadeInOut;
	void Awake (){

		anim = GetComponent<Animator>();
		
		hash = GameObject.FindWithTag (Tags.gameController).GetComponent<HashIDs>();

		playerMovement = GetComponent<PlayerMovement>();

		gameController = GameObject.FindWithTag (Tags.gameController).GetComponent<LastPlayerSighting>();

		sceneFadeInOut = GameObject.FindWithTag (Tags.fader).GetComponent<ScreenFadeInOut>();;
	}

	void PlayerDying ()
	{
		playerDead = true;

		anim.SetBool (hash.deadBool, playerDead);

		AudioSource.PlayClipAtPoint (deathClip, transform.position);
	}

	void PlayerDead ()
	{
		if (anim.GetCurrentAnimatorStateInfo(0).shortNameHash == hash.dyingState) {
			anim.SetBool (hash.dyingState, false);
		}
		anim.SetFloat (hash.speedFloat, 0f);
		playerMovement.enabled = false;
		gameController.position = gameController.resetPosition;
		GetComponent<AudioSource>().Stop ();
	}

	void LevelReset ()
	{
		timer += Time.deltaTime;

		if (timer > resetAfterDeath) {
			sceneFadeInOut.EndScene();
		}
	}

	// Update is called once per frame
	void Update () {
		if (health <= 0f) {
			if (!playerDead) {
				PlayerDying ();
			}else{
				PlayerDead ();
				LevelReset ();
			}
		}
	}
}
