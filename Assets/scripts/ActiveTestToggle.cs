using UnityEngine;
using System.Collections;

public class ActiveTestToggle : MonoBehaviour {
	public GameObject waggle;
	public GameObject patternBash;
	public GameObject buttonBash;
	public GameObject drunkDarts;


	// Use this for initialization
	void Start () {
		waggle.SetActive (false);
		patternBash.SetActive (false);
		buttonBash.SetActive (false);
		drunkDarts.SetActive (false);

		//GameObject newWaggle = (GameObject)Instantiate (waggle, new Vector2 (0, 0), new Quaternion ());
		//newWaggle.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
