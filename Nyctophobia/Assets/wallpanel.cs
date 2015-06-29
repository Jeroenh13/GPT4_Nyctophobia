using UnityEngine;
using System.Collections;

public class wallpanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(PlayerPrefs.GetInt("screw1") == 1 && PlayerPrefs.GetInt("screw2") == 1 && PlayerPrefs.GetInt("screw3") == 1 && PlayerPrefs.GetInt("screw4") == 1)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
	}
}
