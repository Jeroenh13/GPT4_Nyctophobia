using UnityEngine;
using System.Collections;

public class Key1 : Usable {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("hasKeyHallway", 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void doAction()
    {
        PlayerPrefs.SetInt("hasKeyHallway", 1);
        gameObject.SetActive(false);
    }
}
