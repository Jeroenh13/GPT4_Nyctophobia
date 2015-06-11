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
    public GameObject LightObject;
    public CharacterController controller;

	void Update()
	{
        
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();
        LightObject.transform.rotation = thalmicMyo.transform.rotation;

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
            transform.Rotate(0, Input.GetAxis("Horizontal") / 1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * 2, 0);
       }
        if (Input.GetKey(KeyCode.W))
        {
            
            forward = Player.transform.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            forward = Player.transform.TransformDirection(Vector3.forward);
            controller.SimpleMove(-forward);
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
