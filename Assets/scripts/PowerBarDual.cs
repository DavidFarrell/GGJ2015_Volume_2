using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerBarDual : MonoBehaviour {
	
	public Slider spellPowerBar; // ref for the slider
	public Slider maxThresholdSlider;
	public Slider minThresholdSlider;
	
	public float currentPower;
	public float currentMaxThreshold;
	public float currentMinThreshold;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		spellPowerBar.value = currentPower;
		maxThresholdSlider.value = currentMaxThreshold;
		minThresholdSlider.value = currentMinThreshold;
	}
}

