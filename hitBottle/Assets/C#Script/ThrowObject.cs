using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 宣告程式需要的 SteamVR_TrackedObject Component
[RequireComponent(typeof(SteamVR_TrackedObject))] 
public class ThrowObject : MonoBehaviour {

	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;
	public float speedUp=1.0f;
	void Awake () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}

	void FixedUpdate () {
		device = SteamVR_Controller.Input ((int)trackedObj.index);
	}
	void OnTriggerStay(Collider col) {
		Debug.Log ("碰到");
		if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
		{	Debug.Log ("抓起");
			// 將 physics(物理引擎) 關掉
			col.attachedRigidbody.isKinematic = true;
			// 設定controller為parent
			col.gameObject.transform.SetParent(gameObject.transform);
		}
		if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger)) 
		{
			Debug.Log ("放開");
			col.gameObject.transform.SetParent (null);
			col.attachedRigidbody.isKinematic = false;
			tossObject (col.attachedRigidbody); 
		}
	}
	void tossObject(Rigidbody rigidBody) {
		Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
		if (origin != null)
		{	// 轉換速度與轉速到世界空間
			rigidBody.velocity=origin.TransformVector(device.velocity)*speedUp;
			rigidBody.angularVelocity=origin.TransformVector(device.angularVelocity);
		}
		else {
			rigidBody.velocity = device.velocity*speedUp;
			rigidBody.angularVelocity = device.angularVelocity;
		}
	}
}

