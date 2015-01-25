using UnityEngine;
using System.Collections;

public class WaggleRotateIcon : MonoBehaviour {

	public bool isLR;

	// Use this for initialization
	void Start () {
		if (isLR) {
			transform.Rotate(0,0,0);
			//transform.localScale = new Vector3(66,33,1);	
			transform.localPosition = new Vector3(0,0,0); 

		} else {
			transform.Rotate(0,0,90);
			//transform.localScale = new Vector3(33,66,1);
			transform.localPosition = new Vector3(0,0,0); 

		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
