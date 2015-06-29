using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DoorCellar : Usable {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void doAction()
    {
        if(PlayerPrefs.GetInt("KeyBasementGet") == 1)
        {
            transform.DORotate(new Vector3(0, 80, 270), 1);
            setActive(false);
            itemName = "";
        }
    }
}
