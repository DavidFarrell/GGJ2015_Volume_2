using UnityEngine;
using System.Collections;

public class FModTest : MonoBehaviour {
	//FMOD.Studio.EventInstance fmMusic;
//	FMOD.Studio.ParameterInstance fmProgression;

	//FMOD.Studio.EventInstance fmSingle;

	//public int whichShound = 0;
	// Use this for initialization
		//public FMOD_TriggerEvent_JMC dftrigger;void Start () {

		
	//	dftrigger = GetComponent<FMOD_TriggerEvent_JMC> ();
	//	dftrigger.playOneShot (4);

	//	fmSingle = FMOD_StudioSystem.instance.GetEvent ("event:/Single Shot");

	//	fmSingle = FMOD_StudioSystem.instance.GetEvent ("event:/Lose Hit");

		//fmSingle = FMOD_StudioSystem.instance.GetEvent ("event:/Lose Hit");
		//FMOD_StudioSystem.instance.PlayOneShot ("event:/Single Shot", transform.position);
		/*fmMusic = FMOD_StudioSystem.instance.GetEvent("event:/Music");
		fmMusic.start();
		fmMusic.getParameter("Progression", out fmProgression);*/

		//FMOD_StudioSystem.instance.PlayOneShot ("event:/Lose Hit", transform.position);
	//}
	
	// Update is called once per frame
	void Update () {

		//if (whichShound == 10) {
		///	FMOD_StudioSystem.instance.PlayOneShot (sound, transform.position);
		//	FMOD_StudioSystem.instance.play
			//	}
		//Debug.Log ("play");
		//fmSingle = FMOD_StudioSystem.instance.GetEvent ("event:/Lose Hit");
	//	FMOD_StudioSystem.instance.PlayOneShot ("event:/Lose Hit", transform.position);


	//	Debug.Log (fmSingle);
	//	if (Input.GetKeyDown ("space")) {
	//		print ("space key was pressed");
	//		Debug.Log ("play");
	//		fmSingle = FMOD_StudioSystem.instance.GetEvent ("event:/Lose Hit");
			//	fmProgression.setValue(100);
		//}
	}

	void OnDisable()
	{
		//fmMusic.stop (FMOD.Studio.STOP_MODE.IMMEDIATE);
	}
}
