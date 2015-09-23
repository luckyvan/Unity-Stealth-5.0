using UnityEngine;
using System.Collections;

public class AlarmLight : MonoBehaviour {
	
	#region Public field
	public float fadeSpeed = 2f;

	public float highIntensity = 4f;

	public float lowIntensity = 0.5f;

	public float changeMargin = 0.2f;

	public bool alarmOn;
	#endregion

	#region Private field
	private float targetIntensity;

	private Light alarmLight;
	#endregion
	// Use this for initialization
	void Awake () {
		alarmLight = GetComponent<Light>();

		alarmLight.intensity = 0f;

		targetIntensity = highIntensity;
	}
	
	// Update is called once per frame
	void Update () {
	    if (alarmOn) {
			alarmLight.intensity = Mathf.Lerp (alarmLight.intensity, targetIntensity, fadeSpeed*Time.deltaTime);

			CheckTargetIntensity();
			
		}else{
			alarmLight.intensity = Mathf.Lerp (alarmLight.intensity, 0f, fadeSpeed*Time.deltaTime);
		}
	}

	void CheckTargetIntensity ()
	{
		if (Mathf.Abs(alarmLight.intensity - targetIntensity) < changeMargin) {
			targetIntensity = (targetIntensity == highIntensity) ? lowIntensity : highIntensity;
		}
	}
}
