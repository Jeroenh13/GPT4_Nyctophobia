using UnityEngine;
using System.Collections;

public class screwdriver : Usable {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("screwdriverGet", 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void doAction()
    {
        if(PlayerPrefs.GetInt("ropeKnipped") == 1)
        {
            PlayerPrefs.SetInt("screwdriverGet", 1);
            gameObject.SetActive(false);
            
        }
    }
}
