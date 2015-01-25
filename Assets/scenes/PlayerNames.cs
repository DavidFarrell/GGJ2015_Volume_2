using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerNames : MonoBehaviour {

	public string gameSceneName;


	// Use this for initialization
	void Start () {
		PlayerPrefs.SetString("Player1Name", "NO ENTRY INPUT");
		PlayerPrefs.SetString("Player2Name", "NO ENTRY INPUT");
		PlayerPrefs.SetString("Player3Name", "NO ENTRY INPUT");
		PlayerPrefs.SetString("Player4Name", "NO ENTRY INPUT");
		Debug.Log(PlayerPrefs.GetString ("Player1Name"));
	

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Player1Enter(string playerName){
		PlayerPrefs.SetString("Player1Name", playerName);
		Debug.Log(playerName);
	}
	public void Player2Enter(string playerName){
		PlayerPrefs.SetString("Player2Name", playerName);
		Debug.Log(playerName);
	}
	public void Player3Enter(string playerName){
		PlayerPrefs.SetString("Player3Name", playerName);
		Debug.Log(playerName);
	}
	public void Player4Enter(string playerName){
		PlayerPrefs.SetString("Player4Name", playerName);
		Debug.Log(playerName);
	}

	public void confirmNames(){
		Debug.Log ("The following names were entered:");
		Debug.Log (PlayerPrefs.GetString ("Player1Name"));
		Debug.Log (PlayerPrefs.GetString ("Player2Name"));
		Debug.Log (PlayerPrefs.GetString ("Player3Name"));
		Debug.Log (PlayerPrefs.GetString ("Player4Name"));
		Application.LoadLevel (gameSceneName);

	}
}
