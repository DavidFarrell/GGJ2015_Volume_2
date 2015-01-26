using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Helicopter : Spell {

	public string joystick = "R";
	private bool isLeftStick = false;
	public bool clockwise = true;

	private float XAxis;
	private float YAxis;

	private float XWaggle;
	private float YWaggle;

	private string lastAxis = "Y";


	// Use this for initialization
	new void Start () {
		base.Start ();
		if (clockwise){
			YWaggle = 1.0f;
			XWaggle = -1.0f;
		}
		if (!clockwise){
			YWaggle = -1.0f;
			XWaggle = 1.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {

		pollInput ();

		
		// 1x -1y -1x 1y
		// 1x 1y -1x -1y
		if (checkForNextInput()) {
			modifyPower(powerIncrease);
		}

		decayOverTime ();
//		Debug.Log (currentPower ());
		
	}

	bool checkForNextInput(){
		if (lastAxis == "X") {
			if (YAxis == -YWaggle){ // Y axis is opposite previous Y Axis
				lastAxis = "Y";
				YWaggle = YAxis;
				return true;
			}
		}else if (XAxis == -XWaggle){ // X axis is opposite previous X Axis
			lastAxis = "X";
			XWaggle = XAxis;
			return true;
		}
		return false;
	}

	bool checkForBadInput(){
		return false;
	}

	public override void setLeftJoystick(bool isLeft){
		isLeftStick = isLeft;
		GameObject stickText = transform.FindChild("PowerBar/StickID").gameObject;
		stickText.GetComponent<Text>().text = isLeft ? "LS" : "RS" ;
		}

	// overrides
	void pollInput() {

		if (isLeftStick) {
			XAxis = Input.GetAxis (platformSpecificInput("L_XAxis"));
			YAxis = Input.GetAxis (platformSpecificInput("L_YAxis"));
				}
		else{
			XAxis = Input.GetAxis (platformSpecificInput("R_XAxis"));
			YAxis = Input.GetAxis (platformSpecificInput("R_YAxis"));
		}

		if (XAxis > 0.8f) XAxis = 1;
		if (XAxis < -0.8f) XAxis = -1;

		if (YAxis > 0.8f) YAxis = 1;
		if (YAxis < -0.8f) YAxis = -1;
	}

}
