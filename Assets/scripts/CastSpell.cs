using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using HutongGames.PlayMaker;
using System;

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
		FsmBool syncStatus  = FsmVariables.GlobalVariables.FindFsmBool("MonitorSync");

		if (syncStatus.Value) {


			runningScores ();
			// these are individual people's readiness


			Spell p1Spell = player1.GetComponentInChildren<Spell> ();
			Spell p2Spell = player2.GetComponentInChildren<Spell> ();
			Spell p3Spell = player3.GetComponentInChildren<Spell> ();
			Spell p4Spell = player4.GetComponentInChildren<Spell> ();

			if ( p1Spell != null) {
				FsmBool p1Ready = FsmVariables.GlobalVariables.FindFsmBool ("P1Ready");
				p1Ready.Value = p1Spell.thresholdCheck ();
			}

			if (p2Spell != null) {
				FsmBool p2Ready = FsmVariables.GlobalVariables.FindFsmBool ("P2Ready");
				p2Ready.Value = p2Spell.thresholdCheck ();
			}
			if (p3Spell != null) {
				FsmBool p3Ready = FsmVariables.GlobalVariables.FindFsmBool ("P3Ready");
				p3Ready.Value = p3Spell.thresholdCheck ();
			}

			if (p4Spell != null) {
				FsmBool p4Ready = FsmVariables.GlobalVariables.FindFsmBool ("P4Ready");
				p4Ready.Value = p4Spell.thresholdCheck ();
			}

			if ( p1Spell != null && p2Spell != null && p3Spell != null && p4Spell != null) {
				updateScores ();
				// if they press the button, they better be rigggghhht!
				if (Input.GetButtonDown ("ButtonMiddle")) {

					if (checkStatus ()) {
						Debug.Log ("YOU GOT IT");
						gameManagerFSM.SendEvent ("SyncSucceed");
					} else {
						Debug.Log ("FAIL!");
						gameManagerFSM.SendEvent ("SpellFailed");
					}
				}

				
				// this will show if the entire group has their threshold
				FsmBool groupReady = FsmVariables.GlobalVariables.FindFsmBool ("GroupReady");
				groupReady.Value = checkStatus ();

			}
		}
	
	}

	void runningScores(){

		IList scores = new List<int> ();


		if (player1.GetComponentInChildren<Spell> () != null) {
			FsmInt player1Fails = FsmVariables.GlobalVariables.FindFsmInt("P1Score");
			player1Fails.Value = player1.GetComponentInChildren<Spell>().currentFailures();
			scores.Add(player1Fails.Value);
			
		}

		if (player2.GetComponentInChildren<Spell> () != null) {
			FsmInt player2Fails = FsmVariables.GlobalVariables.FindFsmInt("P2Score");
			player2Fails.Value = player2.GetComponentInChildren<Spell>().currentFailures();
			scores.Add(player2Fails.Value);
		}

		if (player3.GetComponentInChildren<Spell> () != null) {
			FsmInt player3Fails = FsmVariables.GlobalVariables.FindFsmInt("P3Score");
			player3Fails.Value = player3.GetComponentInChildren<Spell>().currentFailures();
			scores.Add(player3Fails.Value);
		}

		if (player4.GetComponentInChildren<Spell> () != null) {
			FsmInt player4Fails = FsmVariables.GlobalVariables.FindFsmInt("P4Score");
			player4Fails.Value = player4.GetComponentInChildren<Spell>().currentFailures();
			scores.Add(player4Fails.Value);
		}

		FsmInt worstPlayer = FsmVariables.GlobalVariables.FindFsmInt("WorstPlayer");
		int p = indexOfMaxList(scores);
		worstPlayer.Value = p+1;

	}

	void updateScores() {



		FsmInt player1Fails = FsmVariables.GlobalVariables.FindFsmInt("P1Score");
		player1Fails.Value = player1.GetComponentInChildren<Spell>().currentFailures();
		FsmInt player2Fails = FsmVariables.GlobalVariables.FindFsmInt("P2Score");
		player2Fails.Value = player2.GetComponentInChildren<Spell>().currentFailures();
		FsmInt player3Fails = FsmVariables.GlobalVariables.FindFsmInt("P3Score");
		player3Fails.Value = player3.GetComponentInChildren<Spell>().currentFailures();
		FsmInt player4Fails = FsmVariables.GlobalVariables.FindFsmInt("P4Score");
		player4Fails.Value = player4.GetComponentInChildren<Spell>().currentFailures();
		FsmBool groupFail = FsmVariables.GlobalVariables.FindFsmBool("GroupFail");
		FsmInt worstPlayer = FsmVariables.GlobalVariables.FindFsmInt("WorstPlayer");

		int[] scores = {player1.GetComponentInChildren<Spell>().currentFailures(),player2.GetComponentInChildren<Spell>().currentFailures(),
			player3.GetComponentInChildren<Spell>().currentFailures(),player4.GetComponentInChildren<Spell>().currentFailures()};

		int p = indexOfMax(scores);
		worstPlayer.Value = p+1;

		if((player1.GetComponentInChildren<Spell>().currentFailures() + player2.GetComponentInChildren<Spell>().currentFailures()
		   + player3.GetComponentInChildren<Spell>().currentFailures() + player4.GetComponentInChildren<Spell>().currentFailures()) >  failThreshold)
			groupFail.Value = true;
		else groupFail.Value = false;

	}

	private int indexOfMax(int[] scores) {
		int best = 0;
		int bestIndex = 0;
		for (int i = 0; i < scores.Length; i++) {
			if (scores[i] > best){
				bestIndex = i;
				best = scores[i];
			}
		}
		return bestIndex;
	}

	private int indexOfMaxList(IList scores) {
		int best = 0;
		int bestIndex = 0;
		for (int i = 0; i < scores.Count; i++) {
			if ((int) scores[i] > best){
				bestIndex = i;
				best = (int) scores[i];
			}
		}
		return bestIndex;
	}

	private bool checkStatus() {
		if (player1.GetComponentInChildren<Spell> ().thresholdCheck () && player2.GetComponentInChildren<Spell> ().thresholdCheck () && player3.GetComponentInChildren<Spell> ().thresholdCheck () && player4.GetComponentInChildren<Spell> ().thresholdCheck ()) {
			return true;
		} else {
			return false;
		}
	}
}
