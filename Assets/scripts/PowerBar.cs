using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour {

	public Slider spellPowerBar; // ref for the slider
	public float currentPower;

	public Slider spellThreshold;
	public float currentThreshold;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (currentPower > 100) {
			currentPower = 100;
		} else if (currentPower < 0) {
			currentPower = 0;
		}

		spellPowerBar.value = currentPower;
		spellThreshold.value = currentThreshold;

	}
}

