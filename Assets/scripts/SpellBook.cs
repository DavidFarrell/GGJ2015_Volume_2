using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellBook : MonoBehaviour {

	public GameObject Player1Spell;
	public GameObject Player2Spell;
	public GameObject Player3Spell;
	public GameObject Player4Spell;

	//public GameObject[] spells;

	public GameObject[] joystickSpells;
	public GameObject[] faceSpells;
	public GameObject[] triggerSpells;



	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void assignSpells(){
		clearSpells ();

		GameObject leftJoySpell = joystickSpells [Random.Range (0, joystickSpells.Length )];
		GameObject rightJoySpell = joystickSpells [Random.Range (0, joystickSpells.Length )];
		GameObject faceSpell = faceSpells [Random.Range (0, faceSpells.Length )];
		GameObject triggerSpell = triggerSpells [Random.Range (0, triggerSpells.Length )];


		List<GameObject> spells = new List<GameObject>();
		spells.Add(leftJoySpell);
		spells.Add (rightJoySpell);
		spells.Add(faceSpell);
		spells.Add(triggerSpell);



		List<string> players = new List<string> (){
			"Player1_Widget_SpawnPoint", "Player2_Widget_SpawnPoint", "Player3_Widget_SpawnPoint", "Player4_Widget_SpawnPoint"};

		// players should get different spell types each round
		Shuffle (players);


		Player1Spell = (GameObject)Instantiate (leftJoySpell);
		GameObject player1 = GameObject.Find (players[0]);
		Player1Spell.transform.parent = player1.transform;
		Player1Spell.transform.localPosition = new Vector3 (0, 0, 0);
		Player1Spell.GetComponent<Spell> ().setLeftJoystick (true);
		Player1Spell.SetActive (true);

		Player2Spell = (GameObject)Instantiate (rightJoySpell);
		GameObject player2 = GameObject.Find (players[1]);
		Player2Spell.transform.parent = player2.transform;
		Player2Spell.transform.localPosition = new Vector3 (0, 0, 0);
		Player2Spell.GetComponent<Spell> ().setLeftJoystick (false);
		Player2Spell.SetActive (true);

		Player3Spell = (GameObject)Instantiate (faceSpell);
		GameObject player3 = GameObject.Find (players[2]);
		Player3Spell.transform.parent = player3.transform;
		Player3Spell.transform.localPosition = new Vector3 (0, 0, 0);
		Player3Spell.SetActive (true);

		Player4Spell = (GameObject)Instantiate (triggerSpell);
		GameObject player4 = GameObject.Find (players[3]);
		Player4Spell.transform.parent = player4.transform;
		Player4Spell.transform.localPosition = new Vector3 (0, 0, 0);
		Player4Spell.SetActive (true);


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
		if (Player1Spell != null)
			Destroy (Player1Spell);
		if (Player2Spell != null)
			Destroy (Player2Spell);
		if (Player3Spell != null)
			Destroy (Player3Spell);
		if (Player4Spell != null)
			Destroy (Player4Spell);
	}

	public void fsmIssueSpells(){
		assignSpells ();
	}
}
