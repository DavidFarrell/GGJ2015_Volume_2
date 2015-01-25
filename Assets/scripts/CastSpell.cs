using UnityEngine;
using System.Collections;

public class CastSpell : MonoBehaviour {

	public GameObject gameManagerObj;
	private PlayMakerFSM gameManagerFSM;

	public GameObject player1;

	public GameObject player2;

	public GameObject player3;

	public GameObject player4;

	// Use this for initialization
	void Start () {
		gameManagerFSM = gameManagerObj.GetComponent<PlayMakerFSM> ();
	}
	
	// Update is called once per frame
	void Update () {

		// if they press the button, they better be rigggghhht!
		if (Input.GetButtonDown ("ButtonMiddle")) {
			checkStatus ();
		}
	}

	private bool checkStatus() {
		if (player1.GetComponentInChildren<Spell> ().thresholdCheck () && player2.GetComponentInChildren<Spell> ().thresholdCheck () ) {//&& player3.GetComponentInChildren<Spell> ().thresholdCheck () && player4.GetComponentInChildren<Spell> ().thresholdCheck ()) {
			Debug.Log ("YOU GOT IT");
			gameManagerFSM.SendEvent("SyncSucceed");
			return true;
		} else {
			Debug.Log ("FAIL!");
			gameManagerFSM.SendEvent("SpellFailed");
			return false;
		}
	}
}
