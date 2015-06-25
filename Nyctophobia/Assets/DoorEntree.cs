using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DoorEntree : Usable {

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public override void doAction()
    {
        if(PlayerPrefs.GetInt("hasKey1", 0) == 1)
        {
            transform.DORotate(new Vector3(0, 145, 0), 1f);
            setActive(false);
        }
    }
}
