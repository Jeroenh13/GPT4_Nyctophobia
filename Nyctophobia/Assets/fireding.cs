using UnityEngine;
using System.Collections;

public class fireding : Usable {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("FiredingGet", 0);
	}
	

    public override void doAction()
    {
        PlayerPrefs.SetInt("FiredingGet", 1);
        gameObject.SetActive(false);
    }
}
