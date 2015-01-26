using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DrunkDarts : Spell {
	public bool isLeftStick = true;


	public string horizontalAxis = "L_XAxis";
	public string verticalAxis = "L_YAxis";
	
	private float horizontalMovement;
	private float verticalMovement;

	public GameObject myTarget;
	public GameObject myPlayer;
		
	public float speedDampening = 1;
	public float scoreDampening = 1;
	public float scoreDistance = 1;

	private Vector2 currentForce;
	private Vector2 targetForce;
	public float maxDrunkenness = 2;
	public float drunkChangeSpeed = 1;
	private float currentHangover = 0;
	public float hangoverDuration = 50;
	 	
	public float drunkBounds = 1.5f;

	public float drunkInvincibility = 1;
	public float currentInvincibility = 0;

	// Use this for initialization
	new void Start () {
		base.Start ();

		if (!isLeftStick) {
			horizontalAxis = platformSpecificInput("R_XAxis");
			verticalAxis = platformSpecificInput("R_YAxis");
		}

		currentForce = new Vector2 (0, 0);
		updateDrunkVector();
		myPlayer.transform.localPosition = myTarget.transform.localPosition;


	}
	
	// Update is called once per frame
	void Update () {
		
		// player movement
		pollInput ();
		horizontalMovement = horizontalMovement / speedDampening;
		verticalMovement = (verticalMovement * -1) / speedDampening;
		myPlayer.transform.Translate (new Vector2 (horizontalMovement,verticalMovement ));

		// being drunk
		updateDrunkVector();
		currentForce = iTween.Vector2Update (currentForce, targetForce, drunkChangeSpeed);
		myPlayer.rigidbody2D.AddForce (currentForce);

		// bounds



		/* too far left
		if ((myTarget.transform.localPosition.x + myPlayer.transform.localPosition.x) < -drunkBounds) {
			myPlayer.transform.localPosition = new Vector2( (myTarget.transform.localPosition.x - drunkBounds) , myPlayer.transform.localPosition.y);
		}
		// too far right
		if ((myPlayer.transform.localPosition.x - myTarget.transform.localPosition.x) > drunkBounds) {
			myPlayer.transform.localPosition = new Vector2( (myTarget.transform.localPosition.x + drunkBounds) , myPlayer.transform.localPosition.y);
		} 
		// too high
		if ( (myPlayer.transform.localPosition.y - myTarget.transform.position.y) > drunkBounds) {
			myPlayer.transform.localPosition = new Vector2( myPlayer.transform.position.x,  (myTarget.transform.localPosition.y + drunkBounds) );
		}
		// too low
		if ( (myPlayer.transform.localPosition.y - myTarget.transform.localPosition.y ) <  -drunkBounds) {
			myPlayer.transform.localPosition = new Vector2( myPlayer.transform.localPosition.x,  (myTarget.transform.localPosition.y - drunkBounds) );
		}*/
		Vector2 temp = new Vector2 (0, 0);
		temp.x =  Mathf.Clamp (myPlayer.transform.localPosition.x, -drunkBounds, drunkBounds);
		temp.y =  Mathf.Clamp (myPlayer.transform.localPosition.y, -drunkBounds, drunkBounds);


		currentInvincibility -= Time.deltaTime;
		if (Vector2.Distance (myPlayer.transform.localPosition, temp) > 0) {
			if (currentInvincibility <= 0) {
				modifyFailures(1);
				currentInvincibility=drunkInvincibility;

			}
		}

		myPlayer.transform.localPosition = temp;


		// scoring
		float distance = Vector2.Distance (myTarget.transform.localPosition, myPlayer.transform.localPosition);
		float scoreImprovement = (scoreDistance - distance) / scoreDampening;
		modifyPower (scoreImprovement);
	}

	private void updateDrunkVector() {
		currentHangover -= Time.deltaTime;
	
		if(currentHangover < 0)
		{
			currentHangover = hangoverDuration;
			
			float x = Random.Range((-maxDrunkenness),maxDrunkenness);
			float y = Random.Range ((-maxDrunkenness), maxDrunkenness);
			targetForce = new Vector2 (x, y);
		}

	}

	// overrides
	void pollInput() {
		horizontalMovement = Input.GetAxis (horizontalAxis);
		verticalMovement = Input.GetAxis (verticalAxis);
	}

	public override void setLeftJoystick(bool isLeft){
		isLeftStick = isLeft;
		GameObject stickText = transform.FindChild("PowerBar/StickID").gameObject;
		stickText.GetComponent<Text>().text = isLeft ? "LS" : "RS" ;
	}
}
