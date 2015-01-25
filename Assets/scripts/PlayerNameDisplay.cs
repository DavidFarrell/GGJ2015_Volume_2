using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerNameDisplay : MonoBehaviour {

	public  Text Player1Name;
	public  Text Player1Shadow;
	public  Text Player2Name;
	public  Text Player2Shadow;
	public  Text Player3Name;
	public  Text Player3Shadow;
	public  Text Player4Name;
	public  Text Player4Shadow;

	// Use this for initialization
	void Start () {
		Player1Name.text = PlayerPrefs.GetString ("Player1Name");
		Player1Shadow.text = PlayerPrefs.GetString ("Player1Name");
		Player2Name.text = PlayerPrefs.GetString ("Player2Name");
		Player2Shadow.text = PlayerPrefs.GetString ("Player2Name");
		Player3Name.text = PlayerPrefs.GetString ("Player3Name");
		Player3Shadow.text = PlayerPrefs.GetString ("Player3Name");
		Player4Name.text = PlayerPrefs.GetString ("Player4Name");
		Player4Shadow.text = PlayerPrefs.GetString ("Player4Name");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
