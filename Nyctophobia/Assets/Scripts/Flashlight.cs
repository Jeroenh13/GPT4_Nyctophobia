using UnityEngine;
using System.Collections;

using Pose = Thalmic.Myo.Pose;
using VibrationType = Thalmic.Myo.VibrationType;

public class Flashlight : MonoBehaviour {

	public GameObject myo = null;
	public Light SpotLight;
	public Vector3 forward;
	public int time = 800;
    public ThalmicHub hub;
	private Pose _lastPose = Pose.Unknown;
    public GameObject Player;
    public int speed;
    public CharacterController controller;
    public GameObject directional;
    private Quaternion _antiYaw = Quaternion.identity;
    private float _referenceRoll = 0.0f;
    private float angleChecker = 0;

    private bool syncing = true;

	void Update()
	{
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();
        bool updateReference = false;
        if (thalmicMyo.pose != _lastPose)
        {
            _lastPose = thalmicMyo.pose;

            if (thalmicMyo.pose == Pose.DoubleTap)
            {
                updateReference = true;
            }
        }
        if (Input.GetKey(KeyCode.O))
        {
            updateReference = true;
        }
        
        if (thalmicMyo.xDirection == Thalmic.Myo.XDirection.TowardWrist)
        {
            thalmicMyo.transform.rotation = new Quaternion(transform.localRotation.x,
                                                -transform.localRotation.y,
                                                transform.localRotation.z,
                                                -transform.localRotation.w);
        }

        angleChecker = thalmicMyo.transform.eulerAngles.y;

        
		//InvokeRepeating("Repeat", 1, 1);
		InvokeRepeating ("Repeat", 0, 10);

		if (time % 100 == 0 ){
			//MyLight.intensity -= 1;
		}
		if (SpotLight.intensity == 0) {
			CancelInvoke("Repeat");
			//MyLight.intensity = 8;
		}
        if (Input.GetKey(KeyCode.A) || ((angleChecker <= 335 && angleChecker >= 270) && thalmicMyo.pose == Pose.FingersSpread))
        {
            Player.transform.Rotate(0, Player.transform.position.y -3f, 0);
            _antiYaw = Quaternion.FromToRotation(new Vector3(0, Player.transform.position.y -3, 0), new Vector3(0, 0, 1));
        }
        if (Input.GetKey(KeyCode.D) || ((angleChecker >= 45 && angleChecker <= 90) && thalmicMyo.pose == Pose.FingersSpread))
        {
            Player.transform.Rotate(0, Player.transform.position.y + 1f, 0);
            _antiYaw = Quaternion.FromToRotation(new Vector3(0, Player.transform.position.y + 1, 0), new Vector3(0, 0, 1));
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

        if (Input.GetKey(KeyCode.F))
        {
            directional.SetActive(!directional.gameObject.active);
        }

		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;
		}

        if (updateReference)
        {
            _antiYaw = Quaternion.FromToRotation(
                 new Vector3(myo.transform.forward.x, 0, myo.transform.forward.z),
                 new Vector3(0, 0, 1)
             );

            Vector3 referenceZeroRoll = computeZeroRollVector(myo.transform.forward);
            _referenceRoll = rollFromZero(referenceZeroRoll, myo.transform.forward, myo.transform.up);
        }
            Vector3 zeroRoll = computeZeroRollVector(myo.transform.forward);
            float roll = rollFromZero(zeroRoll, myo.transform.forward, myo.transform.up);
            float relativeRoll = normalizeAngle(roll - _referenceRoll);
            Quaternion antiRoll = Quaternion.AngleAxis(relativeRoll, myo.transform.forward);
            thalmicMyo.transform.rotation = _antiYaw * antiRoll * Quaternion.LookRotation(myo.transform.forward);
            SpotLight.transform.rotation = thalmicMyo.transform.rotation;
        
			/*

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
                 
			}

		    if (thalmicMyo.pose == Pose.FingersSpread || Input.GetKey(KeyCode.S)) {
                forward = Player.transform.TransformDirection(Vector3.back);
                Player.transform.position += forward * speed * Time.deltaTime;
                /*
                Vector3 vec = new Vector3(0,myo.transform.eulerAngles.y, 0);
                Player.transform.position += forward * speed * Time.deltaTime;
                Player.transform.Rotate(vec);
                 
		    }
    */

	}

	void Repeat()
	{
		time -= 1;
	}

    Vector3 computeZeroRollVector(Vector3 forward)
    {
        Vector3 antigravity = Vector3.up;
        Vector3 m = Vector3.Cross(myo.transform.forward, antigravity);
        Vector3 roll = Vector3.Cross(m, myo.transform.forward);

        return roll.normalized;
    }

    // Adjust the provided angle to be within a -180 to 180.
    float normalizeAngle(float angle)
    {
        if (angle > 180.0f)
        {
            return angle - 360.0f;
        }
        if (angle < -180.0f)
        {
            return angle + 360.0f;
        }
        return angle;
    }
    float rollFromZero(Vector3 zeroRoll, Vector3 forward, Vector3 up)
    {
        float cosine = Vector3.Dot(up, zeroRoll);

        Vector3 cp = Vector3.Cross(up, zeroRoll);
        float directionCosine = Vector3.Dot(forward, cp);
        float sign = directionCosine < 0.0f ? 1.0f : -1.0f;

        // Return the angle of roll (in degrees) from the cosine and the sign.
        return sign * Mathf.Rad2Deg * Mathf.Acos(cosine);
    }
}
