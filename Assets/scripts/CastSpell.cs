using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;

public class CastSpell : MonoBehaviour {

	public GameObject gameManagerObj;
	private PlayMakerFSM gameManagerFSM;

	public GameObject player1;

	public GameObject player2;

	public GameObject player3;

	public GameObject player4;

	public int failThreshold = 10;

	// Use this for initialization
	void Start () {
		gameManagerFSM = gameManagerObj.GetComponent<PlayMakerFSM> ();
	}
	
	// Update is called once per frame
	void Update () {

		// if they press the button, they better be rigggghhht!
		if (Input.GetButtonDown ("ButtonMiddle")) {
			updateScores ();
			if  ( checkStatus () ) {
				Debug.Log ("YOU GOT IT");
				gameManagerFSM.SendEvent("SyncSucceed");
			} else {
				Debug.Log ("FAIL!");
				gameManagerFSM.SendEvent("SpellFailed");
			}
		}

		// this will show if the entire group has their threshold
		FsmBool groupReady = FsmVariables.GlobalVariables.FindFsmBool("GroupReady");
		groupReady.Value = checkStatus ();

		// these are individual people's readiness
		FsmBool p1Ready = FsmVariables.GlobalVariables.FindFsmBool("P1Ready");
		p1Ready.Value = player1.GetComponentInChildren<Spell> ().thresholdCheck ();
		FsmBool p2Ready = FsmVariables.GlobalVariables.FindFsmBool("P2Ready");
		p2Ready.Value = player2.GetComponentInChildren<Spell> ().thresholdCheck ();
		FsmBool p3Ready = FsmVariables.GlobalVariables.FindFsmBool("P3Ready");
		p3Ready.Value = player3.GetComponentInChildren<Spell> ().thresholdCheck ();
		FsmBool p4Ready = FsmVariables.GlobalVariables.FindFsmBool("P4Ready");
		p4Ready.Value = player4.GetComponentInChildren<Spell> ().thresholdCheck ();
	
	}

	void updateScores() {
		FsmInt player1Fails = FsmVariables.GlobalVariables.FindFsmInt("P1Score");
		player1Fails.Value += player1.GetComponentInChildren<Spell>().currentFailures();
		FsmInt player2Fails = FsmVariables.GlobalVariables.FindFsmInt("P2Score");
		player2Fails.Value += player2.GetComponentInChildren<Spell>().currentFailures();
		FsmInt player3Fails = FsmVariables.GlobalVariables.FindFsmInt("P3Score");
		player3Fails.Value += player3.GetComponentInChildren<Spell>().currentFailures();
		FsmInt player4Fails = FsmVariables.GlobalVariables.FindFsmInt("P4Score");
		player4Fails.Value += player4.GetComponentInChildren<Spell>().currentFailures();
		FsmBool groupFail = FsmVariables.GlobalVariables.FindFsmBool("GroupFail");
		FsmInt worstPlayer = FsmVariables.GlobalVariables.FindFsmInt("WorstPlayer");
		int[] scores = {player1.GetComponentInChildren<Spell>().currentFailures(),player2.GetComponentInChildren<Spell>().currentFailures(),
			player3.GetComponentInChildren<Spell>().currentFailures(),player4.GetComponentInChildren<Spell>().currentFailures()};

		if((player1.GetComponentInChildren<Spell>().currentFailures() + player2.GetComponentInChildren<Spell>().currentFailures()
		   + player3.GetComponentInChildren<Spell>().currentFailures() + player4.GetComponentInChildren<Spell>().currentFailures()) >  failThreshold)
			groupFail.Value = true;
		else groupFail.Value = false;

	}

	private bool checkStatus() {
		if (player1.GetComponentInChildren<Spell> ().thresholdCheck () && player2.GetComponentInChildren<Spell> ().thresholdCheck () && player3.GetComponentInChildren<Spell> ().thresholdCheck () && player4.GetComponentInChildren<Spell> ().thresholdCheck ()) {
			return true;
		} else {
			return false;
		}
	}
}
