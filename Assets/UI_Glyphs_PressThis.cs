using UnityEngine;
using System.Collections;

public class UI_Glyphs_PressThis : MonoBehaviour {

	public int faceID = 0;
	public Transform ALocation;
	public Transform BLocation;
	public Transform XLocation;
	public Transform YLocation;

	// Use this for initialization
	void Start () {
		// 0 = disabled
		// 1 = A
		// 2 = B
		// 3 = X
		// 4 = Y

		// disable on start up
		//faceID = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (faceID == 0) {
			SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
			sr.enabled=false;
		} else if (faceID == 1) {
			SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
			sr.enabled=true;
			transform.position = ALocation.transform.position;

		} else if (faceID == 2) {
			SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
			sr.enabled=true;
			transform.position = BLocation.transform.position;
		} else if (faceID == 3) {
			SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
			sr.enabled=true;
			transform.position = XLocation.transform.position;
		} else if (faceID == 4) {
			SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
			sr.enabled=true;
			transform.position = YLocation.transform.position;
		} else {
			SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
			sr.enabled=false;
		}
	}
}
