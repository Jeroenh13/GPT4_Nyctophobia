using UnityEngine;
using System.Collections;

using Pose = Thalmic.Myo.Pose;
using VibrationType = Thalmic.Myo.VibrationType;

public class Flashlight : MonoBehaviour {

	public GameObject myo = null;
	public Light MyLight;
	public Vector3 forward;
	public int time = 800;
	private Pose _lastPose = Pose.Unknown;

	void Update()
	{


		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

		//InvokeRepeating("Repeat", 1, 1);
		InvokeRepeating ("Repeat", 0, 10);

		if (time % 100 == 0 ){
			MyLight.intensity -= 1;
		}
		if (MyLight.intensity == 0) {
			CancelInvoke("Repeat");
			MyLight.intensity = 8;
		}



		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;
		}


			if(Input.GetKey(KeyCode.A))
		   	{
				forward = transform.TransformDirection(Vector3.left * 5);
			}

			if (Input.GetKey (KeyCode.D)) {
			forward = transform.TransformDirection(Vector3.right * 5);
			}

			if (Input.GetKey (KeyCode.Q)) {
			//transform.rotation = Quaternion.LookRotation(myCam.transform.rotation);
			}

			if (Input.GetKey (KeyCode.E)) {

			}

			if (thalmicMyo.pose == Pose.Fist || Input.GetKey(KeyCode.W))
		    {
			forward = transform.TransformDirection(Vector3.forward * 5);
			}

		if (thalmicMyo.pose == Pose.FingersSpread || Input.GetKey(KeyCode.S)) {
			forward = transform.TransformDirection(Vector3.back * 5);
		}


	}

	void Repeat()
	{
		time -= 1;
	}

}
