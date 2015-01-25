using UnityEngine;
using UnityEngine.UI;


using System.Collections;

public class Waggle : Spell {
	
	public string axis = "R_XAxis";
	private string penaltyAxis;
	private bool isLR = true;
	public bool isLeftStick;
	private float joystickInput;
	private float penaltyInput;
	private float lastWaggle = 1.0f;
	private float penaltyCutout = 1.0f;

	
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		
		
		pollInput ();
		if (waggleChanged ()) {
			modifyPower (powerIncrease);
		} 
		decayOverTime ();
		penaltyCutout -= Time.deltaTime;

	}
	
	
	// overrides
	void pollInput() {
		joystickInput = Input.GetAxis (axis);
		if (joystickInput > 0.8f) joystickInput = 1;
		if (joystickInput < -0.8f) joystickInput = -1;

		checkForPenalty ();
	}

	void checkForPenalty(){
		penaltyInput = Input.GetAxis (penaltyAxis);
		if ((penaltyInput > 0.8f || penaltyInput < -0.8f) && (penaltyCutout < 0) ) {
			modifyFailures(1);
			penaltyCutout = 1.0f;
		}
	}
	
	public bool waggleChanged(){
		if (joystickInput == -lastWaggle) {
			lastWaggle = joystickInput;

			return true;
		}
		return false;
	}

	public override void setLeftJoystick(bool isLeft) {
		isLeftStick = isLeft;
		axis = isLeftStick ?  "L_XAxis" : "R_XAxis";
		penaltyAxis = isLeftStick ?  "L_YAxis" : "R_YAxis";
		GameObject stickText = transform.FindChild("PowerBar/StickID").gameObject;
		stickText.GetComponent<Text>().text = isLeft ? "LS" : "RS" ;
	}
		

	
}