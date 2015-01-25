using UnityEngine;
using System.Collections;

public class FMOD_TriggerEvent_JMC : MonoBehaviour {

	FMOD.Studio.EventInstance fmAmbience;
	FMOD.Studio.EventInstance fmBGM;
	FMOD.Studio.EventInstance fmBoltLoop;

	FMOD.Studio.ParameterInstance fmBMGProgression;
	FMOD.Studio.ParameterInstance fmBoltProgression;
	FMOD.Studio.ParameterInstance fmAmbienceProgression;

	// Use this for initialization
	void Start () {
		fmAmbience = FMOD_StudioSystem.instance.GetEvent ("event:/Ambience");
		fmBGM = FMOD_StudioSystem.instance.GetEvent ("event:/Music");



		//fmBoltLoop = FMOD_StudioSystem.instance.GetEvent ("event:/Bolt Loop");

		fmAmbience.getParameter("View", out fmAmbienceProgression);
		fmBGM.getParameter("Progression", out fmBMGProgression);
	//	fmBoltLoop.getParameter("Additional", out fmBoltProgression);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void beginAmbienceTrack(){
		fmAmbience.start();
	}

	public void beginMusicTrack(){
		fmBGM.start();
	}

	/*
	public void beginBoltLoop(){
		fmBoltLoop.start();
	}*/

	public void musicProgression(int value){
		// begins at 0, 1 2 3 4 are the people progression?
		// set to 1 when player 2 starts
		// set to 2 when player 3 starts
		// set to 3 when player 4 starts
		// set to 4 when all above threshold
		fmBMGProgression.setValue(value);
	}

/*	public void boltLoopProgression(int value){
		// begins at 0 = player 1 starting
		// set to 1 when player 2 starts
		// set to 2 when player 3 starts
		// set to 3 when player 4 starts
		fmBoltProgression.setValue(value);
	}*/
	
	public void ambientProgression(float value){
		// 0-0.5.49 - down on ground
		// 5-1.0 - up in the sky
		fmAmbienceProgression.setValue(value);
	}

	public void playOneShot( int soundId) {
		string sound = "event:/Lose Hit";
		if (soundId == 1) sound = "event:/Win Hits";
		if (soundId == 2) sound = "event:/VO Loop";
		if (soundId == 3) sound = "event:/Wiz Synth2";//nowork
		if (soundId == 4) sound = "event:/Wiz Synth3";
		if (soundId == 5) sound = "event:/Wiz Synth4";
		if (soundId == 6) sound = "event:/Wiz Synth1";



		FMOD_StudioSystem.instance.PlayOneShot (sound, transform.position);
	}

}
