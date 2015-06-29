using UnityEngine;
using System.Collections;

public class Key4 : Usable {

    public GameObject panelToRemove;
	// Use this for initialization
	void Start () 
    {
        PlayerPrefs.SetInt("KeyBasementGet", 0);
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    public override void doAction()
    {
        PlayerPrefs.SetInt("KeyBasementGet", 1);
        gameObject.SetActive(false);
        panelToRemove.SetActive(false);
    }
}
