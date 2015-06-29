using UnityEngine;
using System.Collections;

public class Switch : Usable {
    public GameObject light;

	// Use this for initialization
	void Start () {
        light.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void doAction()
    {
        transform.Rotate(0, 180, 0);
        setActive(false);
        light.SetActive(true);
    }
}
