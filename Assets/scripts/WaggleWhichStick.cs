using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaggleWhichStick : MonoBehaviour {

	// iws the waggle Left/Right?
	public bool isLR;

	// is the game played on left stick?
	public bool isLS;

	private Text stickText;
	private RectTransform rectRef;

	// Use this for initialization
	void Start () {

		stickText = GetComponent<Text> ();
		rectRef = GetComponent<RectTransform>();

		if (isLR) {
			// text should stay central		
			rectRef.localPosition = new Vector3 (0,0,0);
		} else {
			// text should be repositioned	
			rectRef.localPosition = new Vector3 (-60,30,0);
		}

		if (isLS) {
			stickText.text = "LS";
			// text should read LS		
		} else {
			// text should read RS
			stickText.text = "RS";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
