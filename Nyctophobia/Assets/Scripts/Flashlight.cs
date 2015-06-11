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
    public GameObject Player;
    public int speed;

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
        if (Input.GetKey(KeyCode.A))
        {
            Quaternion lookDir = Player.transform.rotation;
            Debug.Log(lookDir.z);
            Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, lookDir, Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 lookDir = Player.transform.position;
            lookDir.y = 0; // keep only the horizontal direction
            lookDir.x = 0; // keep only the horizontal direction
            lookDir.z = lookDir.z + 2;
            Quaternion curRot = new Quaternion();
            curRot = Player.transform.rotation;
            curRot.SetLookRotation(lookDir);
            Player.transform.rotation = curRot;
        }


		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;
		}
			

			if (Input.GetKey (KeyCode.D)) {
                //Player.transform.position.z = Player.transform.position.z - 5;
			}

			if (Input.GetKey (KeyCode.Q)) {
			//transform.rotation = Quaternion.LookRotation(myCam.transform.rotation);
			}

			if (Input.GetKey (KeyCode.E)) {

			}

			if (thalmicMyo.pose == Pose.Fist || Input.GetKey(KeyCode.W))
		    {
                forward = Player.transform.TransformDirection(Vector3.forward);
                Player.transform.position += forward * speed * Time.deltaTime;
                /*
                Vector3 vec = new Vector3(0,myo.transform.eulerAngles.y, 0);
                Player.transform.position += forward * speed * Time.deltaTime;
                Player.transform.Rotate(vec);
                 */
			}

		    if (thalmicMyo.pose == Pose.FingersSpread || Input.GetKey(KeyCode.S)) {
                forward = Player.transform.TransformDirection(Vector3.back);
                Player.transform.position += forward * speed * Time.deltaTime;
                /*
                Vector3 vec = new Vector3(0,myo.transform.eulerAngles.y, 0);
                Player.transform.position += forward * speed * Time.deltaTime;
                Player.transform.Rotate(vec);
                 */
		    }


	}

	void Repeat()
	{
		time -= 1;
	}

}
