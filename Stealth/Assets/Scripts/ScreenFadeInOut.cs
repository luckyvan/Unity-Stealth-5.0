using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenFadeInOut : MonoBehaviour {
	public float fadeSpeed = 1.5f;

	private bool sceneStarting = true;

	private RawImage screenFader = null;

	private float changeMargin = 0.05f;

	void Awake(){
		screenFader = GetComponent<RawImage>();

		if (screenFader == null) {
			throw new UnityException ("No Screen Fader added");
		}
	}


	void FadeToClear ()
	{
		screenFader.color = Color.Lerp (screenFader.color, Color.clear, Time.deltaTime*fadeSpeed);
	}

	void FadeToBlack ()
	{
		screenFader.color = Color.Lerp (screenFader.color, Color.black, Time.deltaTime*fadeSpeed);
	}

	void StartScene ()
	{
		FadeToClear();

		if (screenFader.color.a <= changeMargin) {
			screenFader.color = Color.clear;
			screenFader.enabled = false;
			sceneStarting = false;
		}
	}

	public void EndScene()
	{
		screenFader.enabled = true;

		FadeToBlack ();

		if (screenFader.color.a >= 1f - changeMargin) {
			Application.LoadLevel (0);
		}
	}
		
	// Update is called once per frame
	void Update () {
		if (sceneStarting) {
			StartScene();
		}
	}
}
