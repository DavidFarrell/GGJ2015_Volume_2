using UnityEngine;
using System.Collections;

public class _DEBUG_AnimTest : MonoBehaviour {

	public GameObject RedWizard;
	public GameObject BlueWizard;
	public GameObject GreenWizard;
	public GameObject YellowWizard;

	public bool testRed;
	public bool testBlue;
	public bool testGreen;
	public bool testYellow;

	private Animator RedAnimator;
	private Animator BlueAnimator;
	private Animator GreenAnimator;
	private Animator YellowAnimator;

	// Use this for initialization
	void Start () {
		RedAnimator = RedWizard.GetComponent<Animator>(); 
		BlueAnimator = BlueWizard.GetComponent<Animator>(); 
		GreenAnimator = GreenWizard.GetComponent<Animator>(); 
		YellowAnimator = YellowWizard.GetComponent<Animator>(); 
	}
	
	// Update is called once per frame
	void Update () {
		// test the red wizard 
		if (testRed) {
			RedAnimator.SetBool ("TargetMet", true);
		} else {	
			RedAnimator.SetBool ("TargetMet", false);
		}

		// test the blue wizard 
		if (testBlue) {
			BlueAnimator.SetBool ("TargetMet", true);
		} else {	
			BlueAnimator.SetBool ("TargetMet", false);
		}

		// test the green wizard 
		if (testGreen) {
			GreenAnimator.SetBool ("TargetMet", true);
		} else {	
			GreenAnimator.SetBool ("TargetMet", false);
		}

		// test the yellow wizard 
		if (testYellow) {
			YellowAnimator.SetBool ("TargetMet", true);
		} else {	
			YellowAnimator.SetBool ("TargetMet", false);
		}
	}


}
