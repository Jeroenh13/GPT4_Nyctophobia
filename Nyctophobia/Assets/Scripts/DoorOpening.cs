using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DoorOpening : MonoBehaviour {
    private RaycastHit hit;
    private bool isOpen = false;
    private bool keyState = false;
    private bool prevkeyKeystate = false;
    private bool candleOut = false;
	public ParticleSystem flame;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        keyState = Input.GetKey(KeyCode.E);
        Transform cam = Camera.main.transform;
        if (Physics.Raycast(cam.position, cam.forward, out hit, 3f))
        {
            GameObject obj = hit.transform.gameObject;
            if (keyState && !prevkeyKeystate)
            {
                if (obj.tag == "candle")
                {
                    candleOut = true;
                    Debug.Log("Kaars is uit");
					flame.gameObject.SetActive(false);
                }
            }
            if (obj.tag == "door" && candleOut == true)
            {
                Debug.Log("ja");
               // obj.GetComponentInChildren<Renderer>().material.color = Color.yellow;
                if (keyState && !prevkeyKeystate)
                {
                    if (isOpen == false)
                    {
                        Debug.Log("Used");
                        Vector3 rotatie = new Vector3(0, 90, 0);
                        obj.transform.DORotate(rotatie, 3);
                        isOpen = true;
                    }
                    else if (isOpen == true)
                    {
                        Debug.Log("Used");
                        Vector3 rotatie = new Vector3(0, 0, 0);
                        obj.transform.DORotate(rotatie, 3);
						isOpen = false;
                    }
                }
                prevkeyKeystate = keyState;
            }
        }
	}
}
