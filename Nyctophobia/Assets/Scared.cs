using UnityEngine;
using System.Collections;

public class Scared : MonoBehaviour {

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
            ai.scared = false;
            ai.scaredmeter = 0;
            ai.range = 4f;
        }
    }
}
