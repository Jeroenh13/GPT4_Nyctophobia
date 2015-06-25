using UnityEngine;
using System.Collections;

public class ScaredMeter : MonoBehaviour {

    public AstarAI ai;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Child")
        {
            ai.scaredmeter += 25;
        }
    }
}
