using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

	public float timeDecay = -1.0f;
	public float timeDecaySpeed = 0.5f;
	public float powerIncrease = 5.0f;
	public float powerDecrease = 10.0f;

	private PowerBar myPowerBar;
	private int power;
	private int failures = 0;
	protected float time;

	// Use this for initialization
	protected void Start () {
		time = timeDecaySpeed;
		myPowerBar = GetComponent<PowerBar>();
		myPowerBar.currentPower = 0;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float currentPower(){
		return myPowerBar.currentPower;
	}

	protected void modifyPower(float powerChange){
		myPowerBar.currentPower += powerChange;

	}

	public int currentFailures(){
		return failures;
	}
	
	public void modifyFailures(int failureChange){
		failures += failureChange;
	}

	void pollInput (){
	}



	public virtual bool thresholdCheck(){
		return myPowerBar.currentPower > myPowerBar.currentThreshold;
	}

	public virtual void setLeftJoystick (bool isLeft){
	}

	public virtual void decayOverTime()
	{
		time -= Time.deltaTime;
		if (time < 0) {
			modifyPower (timeDecay);
			time = timeDecaySpeed;
		}
	}

	public string rightXAxis()
	{
		if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer) {
			return "R_XAxisOSX";
		} else {
			return "R_XAxis";
		}
	}

	public string rightYAxis()
	{
		if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer) {
			return "R_YAxisOSX";
		} else {
			return "R_YAxis";
		}
	}

	public string platformSpecificInput(string inputString)
	{
		if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer) {
			return inputString + "OSX";
		} else 
			return inputString;
	}

	public string leftTrigger()
	{
		if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer) {
			return "TriggersLOSX";
		} else {
			return "TriggersL";
		}
	}




}
