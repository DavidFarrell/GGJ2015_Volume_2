using UnityEngine;
using System.Collections;


public class ButtonBash : PatternBash {

	// Use this for initialization
	new void Start () {
		base.Start();
		setupPattern ();
		
	}

	protected override void setupPattern() {
		string[] patternArray = new string[]{"A","B","X","Y"};
		pattern = patternArray [Random.Range (0, patternArray.Length )];
		//Get First Button to highlight
		currentButton = "Button" + pattern[0];
		faceDict.TryGetValue(currentButton,out buttonValue);
		ButtonsOverlay.GetComponent<UI_Glyphs_PressThis>().faceID = buttonValue;
		
		//Get the animators
		AAnimator = ButtonA.GetComponent<Animator>(); 
		BAnimator = ButtonB.GetComponent<Animator>(); 
		XAnimator = ButtonX.GetComponent<Animator>(); 
		YAnimator = ButtonY.GetComponent<Animator>();
		
		//Light up the buttons contained in the pattern e.g. BABY will not light up X
		if (pattern.Contains("A")) AAnimator.SetBool("On",true);
		if (pattern.Contains("B")) BAnimator.SetBool("On",true);
		if (pattern.Contains("X")) XAnimator.SetBool("On",true);
		if (pattern.Contains("Y")) YAnimator.SetBool("On",true);
		}
			
}

