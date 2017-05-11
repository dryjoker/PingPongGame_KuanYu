using UnityEngine;
using System.Collections;

public class CreateBall : MonoBehaviour {
	public SteamVR_TrackedObject leftController;
	public GameObject ballPref;
	public GameObject emptBall;
	private Vector3 loadBallPos = new Vector3 ((float)-5.84 , (float)23.8 , (float)-7.9);
	//bool reCreate = false;
	void Start () {
		
	}

	void Update () {
		var device = SteamVR_Controller.Input ((int)leftController.index);
		if (device.GetTouchDown (SteamVR_Controller.ButtonMask.Touchpad)) 
		{
			//Instantiate (ballPref, leftController.transform.position, leftController.transform.rotation, emptBall.transform);
			//reCreate = true;
			Instantiate (ballPref, loadBallPos, leftController.transform.rotation);
		} 
		/*
		if (device.GetPressUp (SteamVR_Controller.ButtonMask.Trigger)) {
			foreach (Transform child in emptBall.transform) {
				GameObject.Destroy (child.gameObject);
			}			
		}
		*/
	}

}
