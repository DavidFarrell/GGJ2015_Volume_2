using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;

public class CountdownTimer : MonoBehaviour {

	private PowerBar myPowerBar;
	private int power;
	//public float timeLeft = 30f;
	public float initialTime = 30f;

	public GameObject gameManagerObj;
	private PlayMakerFSM gameManagerFSM;

	// Use this for initialization
	protected void Start () {
		gameManagerFSM = gameManagerObj.GetComponent<PlayMakerFSM> ();
		myPowerBar = GetComponent<PowerBar>();
		//myPowerBar.currentThreshold = ;
		myPowerBar.currentPower = 100;
		FsmVariables.GlobalVariables.FindFsmFloat ("TimeLeft").Value = initialTime;
		
	}

	public void setNewTime(){
		//myPowerBar = GetComponent<PowerBar>();
		//myPowerBar.currentThreshold = ;
		//myPowerBar.currentPower = 100;
//		/timeLeft = initialTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (FsmVariables.GlobalVariables.FindFsmBool ("MonitorSync").Value) {
			FsmVariables.GlobalVariables.FindFsmFloat ("TimeLeft").Value -= (Time.deltaTime);
			float percentage = FsmVariables.GlobalVariables.FindFsmFloat ("TimeLeft").Value / initialTime;
			myPowerBar.currentPower = percentage * 100;

			if (FsmVariables.GlobalVariables.FindFsmFloat ("TimeLeft").Value <= 0) {
				// trigger failure
				//Debug.Log("YOU DIE");
				gameManagerFSM.SendEvent ("TimerExpired");
			}
		}
	}
}
