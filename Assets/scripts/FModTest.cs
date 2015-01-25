using UnityEngine;
using System.Collections;

public class FModTest : MonoBehaviour {
	FMOD.Studio.EventInstance fmMusic;
	FMOD.Studio.ParameterInstance fmProgression;

	FMOD.Studio.EventInstance fmSingle;

	// Use this for initialization
	void Start () {

		fmSingle = FMOD_StudioSystem.instance.GetEvent ("event:/Single Shot");
	

		//FMOD_StudioSystem.instance.PlayOneShot ("event:/Single Shot", transform.position);
		/*fmMusic = FMOD_StudioSystem.instance.GetEvent("event:/Music");
		fmMusic.start();
		fmMusic.getParameter("Progression", out fmProgression);*/
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			print ("space key was pressed");
			fmSingle.start ();
		//	fmProgression.setValue(100);
		}
	}

	void OnDisable()
	{
		//fmMusic.stop (FMOD.Studio.STOP_MODE.IMMEDIATE);
	}
}
