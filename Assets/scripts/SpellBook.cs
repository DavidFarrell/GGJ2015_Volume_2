using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using HutongGames.PlayMaker;

public class SpellBook : MonoBehaviour {
	
	public GameObject Player1Spell;
	public GameObject Player2Spell;
	public GameObject Player3Spell;
	public GameObject Player4Spell;
	
	//public GameObject[] spells;
	
	public GameObject[] joystickSpells;
	public GameObject[] faceSpells;
	public GameObject[] triggerSpells;
	
	private GameObject leftJoySpell;
	private GameObject rightJoySpell;
	private GameObject faceSpell;
	private GameObject triggerSpell;
	
	private List<string> players;
	// Use this for initialization
	void Start () {
		assignSpells ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	
	public void assignSpells(){
		if (Player1Spell != null)
			Destroy (Player1Spell);
		if (Player2Spell != null)
			Destroy (Player2Spell);
		if (Player3Spell != null)
			Destroy (Player3Spell);
		if (Player4Spell != null)
			Destroy (Player4Spell);


		FsmBool p1Ready = FsmVariables.GlobalVariables.FindFsmBool ("P1Ready");
		p1Ready.Value = false;
		FsmBool p2Ready = FsmVariables.GlobalVariables.FindFsmBool ("P2Ready");
		p2Ready.Value = false;
		FsmBool p3Ready = FsmVariables.GlobalVariables.FindFsmBool ("P3Ready");
		p3Ready.Value = false;
		FsmBool p4Ready = FsmVariables.GlobalVariables.FindFsmBool ("P4Ready");
		p4Ready.Value = false;
		
		leftJoySpell = joystickSpells [Random.Range (0, joystickSpells.Length )];
		rightJoySpell = joystickSpells [Random.Range (0, joystickSpells.Length )];
		faceSpell = faceSpells [Random.Range (0, faceSpells.Length )];
		triggerSpell = triggerSpells [Random.Range (0, triggerSpells.Length )];
		
		
		List<GameObject> spells = new List<GameObject>();
		spells.Add(leftJoySpell);
		spells.Add (rightJoySpell);
		spells.Add(faceSpell);
		spells.Add(triggerSpell);
		
		
		
		players = new List<string> (){
			"Player1_Widget_SpawnPoint", "Player2_Widget_SpawnPoint", "Player3_Widget_SpawnPoint", "Player4_Widget_SpawnPoint"} ;
		
		// players should get different spell types each round
		Shuffle (players);
		
		
		//spawns all 4 at once fr
		//for (int i = 1; i <= 4; i++)
		//	spawnPlayerSpell (i);
		
		
		
	}
	
	public void spawnPlayerSpell(int playerNum){
		switch (playerNum) {
		case 1:
		{
			Player1Spell = (GameObject)Instantiate (leftJoySpell);
			GameObject player1 = GameObject.Find (players[0]);
			FsmInt lastPlayer = FsmVariables.GlobalVariables.FindFsmInt ("LastPlayer");
			lastPlayer.Value = player1.GetComponentInChildren<PlayerDetails>().playerNumber;
			Player1Spell.transform.parent = player1.transform;
			Player1Spell.transform.localPosition = new Vector3 (0, 0, 0);
			Player1Spell.GetComponent<Spell> ().setLeftJoystick (true);
			Player1Spell.SetActive (true);
		//	Debug.Log("case1");
			break;
		}
		case 2:
		{
			Player2Spell = (GameObject)Instantiate (rightJoySpell);
			GameObject player2 = GameObject.Find (players[1]);
			FsmInt lastPlayer = FsmVariables.GlobalVariables.FindFsmInt ("LastPlayer");
			lastPlayer.Value = player2.GetComponentInChildren<PlayerDetails>().playerNumber;
			Player2Spell.transform.parent = player2.transform;
			Player2Spell.transform.localPosition = new Vector3 (0, 0, 0);
			Player2Spell.GetComponent<Spell> ().setLeftJoystick (false);
		//	Debug.Log("case2");
			Player2Spell.SetActive (true);
			break;
		}
		case 3:
		{
			Player3Spell = (GameObject)Instantiate (faceSpell);
			GameObject player3 = GameObject.Find (players[2]);
			FsmInt lastPlayer = FsmVariables.GlobalVariables.FindFsmInt ("LastPlayer");
			lastPlayer.Value = player3.GetComponentInChildren<PlayerDetails>().playerNumber;
			Player3Spell.transform.parent = player3.transform;
			Player3Spell.transform.localPosition = new Vector3 (0, 0, 0);
		//	Debug.Log("case3");
			Player3Spell.SetActive (true);
			break;
		}
		case 4:
		{
			Player4Spell = (GameObject)Instantiate (triggerSpell);
			GameObject player4 = GameObject.Find (players[3]);
			FsmInt lastPlayer = FsmVariables.GlobalVariables.FindFsmInt ("LastPlayer");
			lastPlayer.Value = player4.GetComponentInChildren<PlayerDetails>().playerNumber;
			Player4Spell.transform.parent = player4.transform;
			Player4Spell.transform.localPosition = new Vector3 (0, 0, 0);
		//	Debug.Log("case4");
			Player4Spell.SetActive (true);
			break;
		}
			
			
		}
		
	}
	
	
	public void Shuffle(IList spellList)  
	{   
		for (int i = 0; i < spellList.Count; i++) {
			string temp = (string)spellList[i];
			int randomIndex = Random.Range(i, spellList.Count);
			spellList[i] = spellList[randomIndex];
			spellList[randomIndex] = temp;
		}
	}
	
	public void clearSpells(){
		assignSpells ();
	}
	
}

