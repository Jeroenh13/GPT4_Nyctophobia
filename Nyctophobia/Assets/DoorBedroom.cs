using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DoorBedroom : Usable {

	// Use this for initialization
	void Start () 
    {
        setActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(PlayerPrefs.GetInt("Key3Get") == 1)
        {
            setActive(true);
        }
	}

    public override void doAction()
    {
        transform.DORotate(new Vector3(0, 10, 270), 1F);
        itemName = "";
        setActive(false);
    }
}
