using UnityEngine;
using System.Collections;

public class BallCollision : MonoBehaviour {
	#region
	private Rigidbody rigidBall;
	int isColl = 0;
	#endregion

	void Start () 
	{
		rigidBall = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (isColl == 1 )
		{
			//rigidBall.velocity = new Vector3(0 ,0 , device.angularVelocity.z);
			//rigidBall.AddForce(new Vector3(0f,0f,20f)); //延Z軸正向的力
			rigidBall.AddForce(new Vector3(0f,-5f,20f)); //延Z軸正向的力 y軸向下力
		}
		if (isColl == -1) 
		{
			//rigidBall.velocity = new Vector3(-device.angularVelocity.x , -device.angularVelocity.y , -device.angularVelocity.z);
			//rigidBall.AddForce(new Vector3(0f,0f,-20f)); //延Z軸反向的力
			rigidBall.AddForce(new Vector3(0f,-5f,-20f)); //延Z軸反向的力 y軸向下力
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Racket") {
			print("有打中 球拍"); //在除錯視窗中顯示OK
			isColl = 1;
		} else if (col.gameObject.name == "Wall") {
			print("有打中 牆壁"); //在除錯視窗中顯示OK
			isColl = -1;
		}
	}
}