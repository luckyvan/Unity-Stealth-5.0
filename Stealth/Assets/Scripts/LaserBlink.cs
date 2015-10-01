using UnityEngine;
using System.Collections;

public class LaserBlink : MonoBehaviour {
	public float onTime; //after OnTime turn off the light
	public float offTime; //after OffTime turn On the light

	private float timer;  //timer use to document the time.

	private Renderer laserRenderer;

	private Light laserLight;
	// Use this for initialization
	void Awake () {
		timer = 0f;

		laserRenderer = GetComponent<Renderer>();
		laserLight = GetComponent<Light>();
	}

	void SwitchBeam ()
	{
		timer = 0f; //reset timer

		laserRenderer.enabled = !laserRenderer.enabled;
		laserLight.enabled = !laserLight.enabled;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (laserRenderer.enabled && timer > onTime) {
			SwitchBeam();
		}

		if (!laserRenderer.enabled && timer > offTime) {
			SwitchBeam();
		}
	}
}
