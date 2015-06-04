using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {


	public AudioSource mySource;
	public AudioClip myClip;
	private int lastTime;

	// Use this for initialization
	void Start () {
		lastTime = 200;
	}
	
	// Update is called once per frame
	void Update () {
		lastTime++;
	}

	void OnTriggerEnter()
	{
		if (lastTime > 300) {
			mySource.PlayOneShot (myClip);
			lastTime = 0;
		}
	}
}
