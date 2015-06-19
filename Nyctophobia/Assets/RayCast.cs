using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour {

	private RaycastHit hit;
	private bool keyState = false;
	private bool prevKeyState = false;
	private GameObject obj = null;
	public GameObject raycastOrigin;
	public Light myLight;
	public Camera myCam;
	public bool shutdown = false;

	// Update is called once per frame
	void Update () {
		keyState = Input.GetKey (KeyCode.E);
		Transform cam = raycastOrigin.transform;
		Debug.DrawRay (raycastOrigin.transform.position, Vector3.forward, Color.magenta,10000000000000F);
		if (Physics.Raycast (cam.position, cam.forward, out hit, 100000000000000000000F)) {
			Debug.DrawRay(raycastOrigin.transform.position,Vector3.forward,Color.green);
			obj = hit.transform.gameObject;
			if(obj.tag == "Start")
			{
				if(Input.GetMouseButtonDown(0))
				{
					shutdown = true;
					InvokeRepeating("LowerLight",0.1F,0.1F);
					
				}
			}
			if(obj.tag == "Exit")
			{
				if(Input.GetMouseButtonDown(0))
				{
					Application.Quit();
				}
			}
		}
	

	 if (shutdown && myLight.intensity <= 0) {
			Application.LoadLevel(1);
		}
	}

	public void LowerLight()
	{
		myLight.intensity -= 0.1F;
	}
}
