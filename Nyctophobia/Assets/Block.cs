using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

    bool standingstill = false;
    public AstarAI ai;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Child" && standingstill == false)
        {
            standingstill = true;
            ai.standingstill = true;
        }
        if (other.gameObject.tag == "Player" && standingstill == true)
        {
            standingstill = false;
            ai.standingstill = false;
        }
    }
}
