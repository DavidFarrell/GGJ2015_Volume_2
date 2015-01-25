using UnityEngine;
using System.Collections;

public class PressureHold : Spell {

	public string triggerChoice; //either "TriggersL" or "TriggersR"
	public float penaltyTimer = 1.0f;
	private float penaltyTimerCurrent;

	private float joystickInput;
	public float scaleFactor = 1;

	private PowerBarDual myPowerBarDual;


	// Use this for initialization
	new void Start () {
		time = timeDecaySpeed;
		myPowerBarDual = GetComponent<PowerBarDual>();
		myPowerBarDual.currentMinThreshold = 10;
		myPowerBarDual.currentMaxThreshold = 100;
		myPowerBarDual.currentPower = 0;

	}

	new public float currentPower(){
		return myPowerBarDual.currentPower;
	}

	new protected void modifyPower(float powerChange){
		myPowerBarDual.currentPower += powerChange;
		
	}

	 public override bool thresholdCheck(){
		return (myPowerBarDual.currentPower > myPowerBarDual.currentMinThreshold && myPowerBarDual.currentPower < myPowerBarDual.currentMaxThreshold) ;
	}

	// Update is called once per frame
	void Update () {
		pollInput();
		if (thresholdCheck()) penaltyTimerCurrent = penaltyTimer;
		timeDecay = scaleFactor * joystickInput;
		decayOverTime();

		if (myPowerBarDual.currentPower < 0)
						myPowerBarDual.currentPower = 0;
		if (myPowerBarDual.currentPower > 100)
						myPowerBarDual.currentPower = 100;
		if(penaltyTimerCurrent <= 0) {
			penaltyTimerCurrent = penaltyTimer;
			modifyFailures(1);
			Debug.Log ("PressureHold fail");
		}
	}

	void pollInput() {
		joystickInput = Input.GetAxis (triggerChoice);
	}

	public override void decayOverTime()
	{
		time -= Time.deltaTime;
		penaltyTimerCurrent -= Time.deltaTime;

		if (time < 0) {
			modifyPower (timeDecay);
			time = timeDecaySpeed;
		}
	}
	
}
